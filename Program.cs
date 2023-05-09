using System;
using System.Reflection;

namespace ReflectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створення об'єкту класу MyClass
            MyClass myClass = new MyClass("Hello", 123, true, 4.56, 'A');

            // Виклик методів, які використовуються для демонстрації роботи з Type, TypeInfo, MemberInfo, FieldInfo та MethodInfo
            DisplayTypeInfo(myClass.GetType());
            DisplayFieldInfo(myClass);
            DisplayMethodInfo(myClass);
        }

        // Клас, який містить не менше 5 полів та не менше 3 методів
        class MyClass
        {
            public string strField;
            private int intField;
            protected bool boolField;
            internal double doubleField;
            protected internal char charField;

            public MyClass(string str, int i, bool b, double d, char c)
            {
                strField = str;
                intField = i;
                boolField = b;
                doubleField = d;
                charField = c;
            }

            public void Method1()
            {
                Console.WriteLine("Method1 is called.");
            }

            private void Method2()
            {
                Console.WriteLine("Method2 is called.");
            }

            protected void Method3()
            {
                Console.WriteLine("Method3 is called.");
            }

            public int Method4(string str)
            {
                Console.WriteLine("Method4 is called with parameter: " + str);
                return str.Length;
            }
        }

        // Метод, який виводить інформацію про клас за допомогою Type та TypeInfo
        static void DisplayTypeInfo(Type type)
        {
            Console.WriteLine("Type name: " + type.Name);
            Console.WriteLine("Full type name: " + type.FullName);
            Console.WriteLine("Assembly name: " + type.Assembly.FullName);

            TypeInfo typeInfo = type.GetTypeInfo();
            Console.WriteLine("Is class public: " + typeInfo.IsPublic);
            Console.WriteLine("Is class abstract: " + typeInfo.IsAbstract);
            Console.WriteLine("Is class sealed: " + typeInfo.IsSealed);
        }

        // Метод, який виводить інформацію про поля класу за допомогою FieldInfo
        static void DisplayFieldInfo(object obj)
        {
            Type type = obj.GetType();

            foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine("Field name: " + fieldInfo.Name);
                Console.WriteLine("Field type: " + fieldInfo.FieldType);
                Console.WriteLine("Field value: " + fieldInfo.GetValue(obj));
            }
        }

        // Метод, який викликає методи класу за допомогою MethodInfo
        static void DisplayMethodInfo(object obj)
        {
            Type type = obj.GetType();
            MethodInfo methodInfo = type.GetMethod("Method4");

            object[] parameters = new object[] { "Hello, World!" };
            int result = (int)methodInfo.Invoke(obj, parameters);

            Console.WriteLine("Method4 result: " + result);
        }
    }
}
