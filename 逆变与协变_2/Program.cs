using System;
using System.Collections.Generic;

namespace 逆变与协变_2
{


    //定义一个接口 演示 out 关键字
    //public interface IMyList<out T>
    //{
    //    T GetElement();
    //}

    //public class MyList<T> : IMyList<T>
    //{
    //    public T GetElement()
    //    {
    //        return default(T);
    //    }
    //}

    //public interface IMyList<out T>
    //{
    //    T GetElement();
    //    void ChangeT(T t);//T 被 out 修饰只能作为输出 所以报错
    //}

    //public class MyList<T> : IMyList<T>
    //{
    //    public T GetElement()
    //    {
    //        return default(T);
    //    }
    //    public void ChangeT(T t)
    //    {

    //    }
    //}

    //public interface IMyList<in T>
    //{
    //    T GetElement();//T 被 in 修饰只能作为参数使用，不能作为返回值所以报错
    //    void ChangeT(T t);
    //}

    //public class MyList<T> : IMyList<T>
    //{
    //    public T GetElement()
    //    {
    //        return default(T);
    //    }
    //    public void ChangeT(T t)
    //    {

    //    }
    //}

    public abstract class Animal { };
    public class Dog : Animal { string name => "小狗"; };

    public interface IMyList<in T>
    {
        void ChangeT(T t);
    }

    public class MyList<T> : IMyList<T>
    {
        public void ChangeT(T t)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //out 参数协变 小变大
            //IMyList<Dog> myDogs = new MyList<Dog>();
            //IMyList<Animal> myAnimals = myDogs;

            //in 参数逆变 大变小 可以使用强制转换关系是Dog派生自Animal
            IMyList<Animal> myAnimals = new MyList<Animal>();
            IMyList<Dog> myDogs = myAnimals;

            MyList<Animal> myAnimale = new MyList<Animal>();
            MyList<Dog> myDog = (MyList<Dog>)myAnimals;
        }
    }
}
