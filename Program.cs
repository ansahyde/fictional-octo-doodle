namespace ConsoleApp1
{
    using System.Collections;
    using System.Collections.Generic;
    using Prism.Unity;
    using Prism.Ioc;

    internal interface IExtendedEnumerable<T>
        : IEnumerable<T>
    {
        void DoSomething();
    }

    internal class ExtendedEnumerableImplementation<T>
        : IExtendedEnumerable<T>
    {
        public void DoSomething()
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield break;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var extension = new UnityContainerExtension();
            _ = extension.Register<IExtendedEnumerable<int>, ExtendedEnumerableImplementation<int>>();
            _ = extension.Resolve<IExtendedEnumerable<int>>(); // Throws InvalidCastException
        }
    }
}
