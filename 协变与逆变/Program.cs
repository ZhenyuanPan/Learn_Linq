using System;
using System.Collections.Generic;
using System.Linq;

namespace 协变与逆变
{
    public abstract class Animal { }
    public class Dog : Animal
    {
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            //这个是可以的 因为狗是属于动物的 大的包括小的
            Dog dog = new Dog();
            Animal animal = dog;

            #region 
            //list<dog> 不是继承自animal，所以现在不能这样去赋值
            List<Dog> dogs = new List<Dog>();
            //List<Animal> animals = dogs; 

            //我们像这样写怎么办? 可以这样 这样写比较麻烦 也不方便阅读(采用linq的方法)
            //List<Animal> animals2 = dogs.Select(d => (Animal)d).ToList();

            //小变大 协变 无法强制转换 关系是Dog派生自Animal
            //List<Animal> animals = (List<Animal>)dogs;

            /*
                所以微软给我们加了两个关键字in out 一个进一个出
                现在可以这样理解这两个关键字out(协变,输出结果) in(逆变,作为参数)
                如果一个泛型参数被标记为out 那么代表他是用来输出,作为结果返回。
                如果一个泛型参数被标记为in 那代表他是用来输入的，只能用来作为参数。
                来观察下面这个写法 为啥就行了 out 参数!
            */
            IEnumerable<Dog> someDogs = new List<Dog>();
            //协变 小变大
            IEnumerable<Animal> someAnimals = someDogs;//强制转换为合法

            //来看下逆变 dog => animal in关键字只能作为参数
            //action 是系统定义的委托，委托是存储方法的一种特殊的数据类型。这不是带in参数了吗 in参数泛型委托 in只能当做参数来使用 
            //这里传递了一个匿名方法 
            Action<Animal> actionAnimal = new Action<Animal>(a => { Console.WriteLine("动物叫"); });
            //逆变 大变小
            Action<Dog> actionDog = actionAnimal;
            //这个委托 是有一个in参数的 所以调用这个委托需要给他传递一个参数
            actionDog(dog);

            #endregion

        }
    }
}
