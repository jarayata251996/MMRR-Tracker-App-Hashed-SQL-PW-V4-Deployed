using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MMRR_Tracker
{
    public class writingReadingObject
    {
        public static string ReadFromFile(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }

        [Serializable]
        public class MyObject
        {
            public string connectionAppKey { get; set; }
            public string AppKey { get; set; }
        }

        public static void WriteObjectArrayToFile(MyObject[] objectArray, string filePath)
        {
            try
            {
                if (objectArray == null)
                {
                    throw new ArgumentNullException(nameof(objectArray), "Object array cannot be null.");
                }
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, objectArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MMRR App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static MyObject[] ReadObjectArrayFromFile(string filePath)
        {
            MyObject[] objectArray = null;

            try
            {
                // Read the object array from the file
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    objectArray = (MyObject[])formatter.Deserialize(stream);
                }

                Console.WriteLine("Object array read from file successfully.");
            }
            catch (System.Runtime.Serialization.SerializationException ex)
            {
                Console.WriteLine("A serialization error occurred while reading from the file: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading from the file: " + ex.Message);
            }

            return objectArray;
        }

        public static string getConnectionAppKey()
        {
            string output = "";
            string filePath = Directory.GetCurrentDirectory() + "\\biDev.dat";
            MyObject[] readObjectArray = ReadObjectArrayFromFile(filePath);
            if (readObjectArray != null)
            {
                Console.WriteLine("Serialized object array contents:");
                foreach (MyObject obj in readObjectArray)
                {
                   return obj.connectionAppKey;
                }
            }
            return output;
        }

        public static string getAppKey()
        {
            string output = "";
            string filePath = Directory.GetCurrentDirectory() + "\\biDev.dat";
            MyObject[] readObjectArray = ReadObjectArrayFromFile(filePath);

            if (readObjectArray != null)
            {
                foreach (MyObject obj in readObjectArray)
                {
                  
                    return obj.AppKey;
                }
            }
            return output;
        }

    }

}
