using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Classes;

namespace ClassLibrary2.Osu.GameplayElements.Beatmaps
{
    public class Beatmap //GClass257 -- Outdated (Don't need?)
    {

        public const String ClassName = "\u0023\u003Dq9Q5oSBMb0Kcd34NJO8LjuVCVx_e2WHcf5En68SfIh1hqXEXq4uWZUXcvflMy1IKJ";
        private Type actualType;        //Obfuscated Name for Reflection
        private object actualObject;        //Obfuscated Name for Reflection
        private Assembly assembly;
        //Members
        //GCLass256 - Outdated
        public static String ApproachRate = "\u0023\u003Dq5dlJZxr7J37xNGFJ0aYIz8g9oXBRuqbkpVTcf90ZgD8\u003D";//float
        public static String CircleSize = "\u0023\u003DqFUF9cvBHMVdRopJrF1w8l8rdXRiX1Tz2Wda0PQslzJU";//float
        public static String HPDrain = "\u0023\u003DqNV7Htqpikt_lS8vmlhAICSh3NF8bG8V7wer6QWRefZE\u003D";//float
        public static String OverallDifficulty = "\u0023\u003DqvBgHN2LGuN7Fz2V_ARKo95F1Kf5DuBI1jC19rVW9AKw\u003D";//float
        public static String checksum = "\u0023\u003Dq2zAC4K6oAvCepAgdN7as0gwVJ5phX_w0UtETo9OFIFk\u003D";
        public static String Artist = "\u0023\u003Dq9OV9pWJyPbZXgj_6\u0024LeL8g\u003D\u003D";
        public static String Name = "\u0023\u003DqcAQ5H2XRP6KkZn0eQCzOvw";
        //GClass257 - Outdated
        public const String FolderInstance = "\u0023\u003DqSumd7AfqlXlYqfo0qvnpqcrWA0Pa7EpGSsrLD5VCqbs\u003D";
        public const String FileNameInstance = "\u0023\u003Dq8cO7M3\u00249keDAiTbErtwcvA\u003D\u003D";
        public const String AudioFileInstance = "\u0023\u003DqWXlCZapyXCoLBKBwriHs3g\u003D\u003D";
        public const String ChecksumInstance = "\u0023\u003Dq\u0024FFCesZ99cF3G6RawspHq0wOI6NsJAuIV_OCBO1UlhE\u003D";

        public bool IsValid = false;

        private MemberInfo _folder;
        public String Folder
        {
            get
            {

                if (_folder == null)
                {
                _folder = actualType.GetMember(FolderInstance, BindingFlags.NonPublic | BindingFlags.Instance).First();
                    if (_folder == null)
                    {
                        return String.Empty;

                    }
                }
                return Helper.GetValue<String>(_folder, actualObject);
            }
        }

        private MemberInfo _fileName;
        public String FileName
        {
            get
            {

                if (_fileName == null)
                {
                    _fileName = actualType.GetMember(FileNameInstance, BindingFlags.NonPublic | BindingFlags.Instance).First();
                    if (_fileName == null)
                    {
                        return String.Empty;

                    }
                }
                return Helper.GetValue<String>(_fileName, actualObject);
            }
        }

        private MemberInfo _audioFile;
        public String AudioFile
        {
            get
            {
                if (_audioFile == null)
                {
                    _audioFile = actualType.GetMember(AudioFileInstance, BindingFlags.NonPublic | BindingFlags.Instance).First();
                    if (_audioFile == null)
                    {
                        return String.Empty;

                    }
                }
                return Helper.GetValue<String>(_audioFile, actualObject);
            }
        }

        private MemberInfo _checksum;
        public String Checksum
        {
            get
            {
                if (_checksum == null)
                {
                    _checksum = actualType.GetMember(ChecksumInstance, BindingFlags.NonPublic | BindingFlags.Instance).First();
                    if (_checksum == null)
                    {
                        return String.Empty;

                    }
                }
                return Helper.GetValue<String>(_checksum, actualObject);
            }
        }

        public List<HitObject> HitObjects; 

        public Beatmap(object classObject, List<HitObject> hitObjects)
        {
            if (classObject == null) return;

            actualObject = classObject;
            actualType = classObject.GetType();
            IsValid = true;
            HitObjects = hitObjects;
        }

        public void Dump()
        {
            foreach (var memberInfo in actualType.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var value = Helper.GetValue<object>(memberInfo, actualObject);
                Console.WriteLine("Name: {0} Content: {1}", memberInfo.Name, value ?? "");
            }
        }

        public void List()
        {
            
            var piTheList = actualType.GetMember("\u0023\u003Dq_IF1_pL75ujmLrv0udMg2Q\u003D\u003D", BindingFlags.NonPublic | BindingFlags.Instance).First();
            Type t = assembly.GetType("\u0023\u003DqNJb1eF7vlmg2j14fJqafMgMbIywZPbHb2\u0024p3xop4UO30flqrjMWTy_mZweU6li3J");
            IList oTheList = Helper.GetValue<object>(piTheList, actualObject) as IList;
            Console.WriteLine(oTheList.Count);
            foreach (var item in oTheList)
            {
                foreach (var memberInfo in item.GetType().GetMembers( BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    var value = Helper.GetValue<object>(memberInfo, item);
                   // Console.WriteLine("Name: {0} Content: {1}", memberInfo.Name, value ?? "" );
                }
            }
        }

        public void Dictionary()
        {
            var piTheTheClass = actualType.GetMember("\u0023\u003DqbXoSRVY644BVf6yv_2uAmw\u003D\u003D", BindingFlags.NonPublic | BindingFlags.Instance).First();

            foreach (Type iType in piTheTheClass.GetType().GetInterfaces())
            {
                if (iType.IsGenericType && iType.GetGenericTypeDefinition()
                    == typeof(IDictionary<,>))
                {
                    typeof(Beatmap).GetMethod("ShowContents")
                        .MakeGenericMethod(iType.GetGenericArguments())
                        .Invoke(null, new object[] { piTheTheClass });
                    break;
                }
            }
            Console.WriteLine("Loop/");


        }
        public static void ShowContents<TKey, TValue>(
    IDictionary<TKey, TValue> data)
        {
            Console.WriteLine("No call");
            foreach (var pair in data)
            {
                Console.WriteLine(pair.Key + " = " + pair.Value);
            }
        }

    }
}
