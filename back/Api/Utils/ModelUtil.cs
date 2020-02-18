using Keras.Models;
using Numpy;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public static class ModelUtil
    {
        const string MODEL_PATH = @"\models\xor.json";
        const string WEIGHTS_PATH = @"\models\xor.h5";
        public static BaseModel model;
        public static BaseModel Model
        {
            get
            {
                if (model == null)
                {
                    Init();
                }
                return model;
            }
        }

        public static void Init()
        {
            try
            {
                using (Py.GIL())
                {
                    if (model == null)
                    {
                        string path = Directory.GetCurrentDirectory();
                        model = Sequential.ModelFromJson(File.ReadAllText(path + MODEL_PATH));
                        model.LoadWeight(path + WEIGHTS_PATH);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static string TestNDarray(float[] input)
        {
            try
            {
                string result = "-";
                var array = new float[1, input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    array[0, i] = input[i];
                }

                using (Py.GIL())
                {
                    var ndArray = new NDarray(array);
                    result = ndArray.ToString();
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static string Predict(float[] input)
        {
            try
            {
                var array = new float[1, input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    array[0, i] = input[i];
                }

                string result;
                using (Py.GIL())
                {
                    var ndArray = new NDarray(array);
                    var prediction = Model.Predict(ndArray);
                    result = $"Предсказание для {ndArray.ToString()} = {prediction.ToString()}";
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
