using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ClassLibrary2.Helpers;
using ClassLibrary2.Osu.Classes;
using Fasterflect;

namespace ClassLibrary2.Osu.GameplayElements
{
    class HitObjectManager //Class757
    {
        public const String HitObjectsInstance = "\u0023\u003Dqy1b045GbJfvjolRk4ITPmw\u003D\u003D";
        public const String HitObjectInstance = "\u0023\u003DqZWummuknydgX679Sisqk9w\u003D\u003D";
        private object actualObject;
        private Type actualType;
        public bool IsValid
        {
            get { return actualObject != null; }
        }

        private static MemberInfo _hitObjects;
        public List<HitObject> HitObjects
        {
            get
            {
                if (_hitObjects == null)
                {
                    _hitObjects = actualType.GetMember(HitObjectsInstance,
                        BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
                    if (_hitObjects == null)
                    {
                        return null;
                    }
                }
                var list = Helper.GetValue<object>(_hitObjects, actualObject) as IList;
                List<HitObject> m = new List<HitObject>();
                foreach (var item in list)
                {
                    //Console.WriteLine(item.GetFieldValue(HitObject.StartTimeInstance));
                    m.Add(new HitObject(item));
                }

                return m;
            }
        }

        public MemberInfo _hitObject;
        public HitObject CurrentHitObject
        {
            get
            {
                if (_hitObject == null)
                {
                    _hitObject = actualType.GetMember(HitObjectInstance,
                        BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
                    if (_hitObject == null)
                    {
                        return null;
                    }
                }
                var value = Helper.GetValue<object>(_hitObject, actualObject);
                return new HitObject(value);
            }
        }

        public HitObjectManager(object classObject)
        {
            if (classObject == null) return;

            actualObject = classObject;
            actualType = classObject.GetType();

            /*foreach (var memberInfo in actualType.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance))  
            {
                var value = Helpers.Helper.GetValue<object>(memberInfo, actualObject);
                Console.WriteLine("Name: {0}. Value: {1} ", memberInfo.Name, value);
            }*/
        }
    }
}
