using System;
using System.Reflection;
using NextGateForPrism.Tests.ViewModels;
using NextGateForPrism.Tests.Views;
using Xunit;

namespace NextGateForPrism.Tests
{
    public class ViewTypeToViewModelTypeResolverFixture
    {
        [Fact]
        public void ResolveWhenArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => ViewTypeToViewModelTypeResolver.Resolve(null));

        }

        [Fact]
        public void ResolveWhenViewOfSameAssembly()
        {
            var actual = ViewTypeToViewModelTypeResolver.Resolve(typeof(MockView));
            Assert.Equal(typeof(MockViewModel), actual);
        }

        [Fact]
        public void ResolveWhenPageOfSameAssembly()
        {
            var actual = ViewTypeToViewModelTypeResolver.Resolve(typeof(MockView));
            Assert.Equal(typeof(MockViewModel), actual);
        }

        [Fact]
        public void ResolveWhenPageOfDifferentAssembly()
        {
            ViewTypeToViewModelTypeResolver.AssignAssemblies<TestPage, TestPageViewModel>();
            var actual = ViewTypeToViewModelTypeResolver.Resolve(typeof(TestPage));
            Assert.Equal(typeof(TestPageViewModel), actual);
        }
    }

    namespace Views
    {
        public class MockView
        {
        }

        public class MockPage
        {
        }
    }

    namespace ViewModels
    {
        public class MockViewModel
        {
        }

        public class MockPageViewModel
        {
        }
    }
}
