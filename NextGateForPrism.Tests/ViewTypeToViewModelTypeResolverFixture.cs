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
        public void ResolveForViewModelTypeWhenArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => PageNavigationTypeResolver.ResolveForViewModelType(null));
        }

        [Fact]
        public void ResolveForViewModelTypeWhenViewOfSameAssembly()
        {
            var actual = PageNavigationTypeResolver.ResolveForViewModelType(typeof(MockView));
            Assert.Equal(typeof(MockViewModel), actual);
        }

        [Fact]
        public void ResolveForViewModelTypeWhenPageOfSameAssembly()
        {
            var actual = PageNavigationTypeResolver.ResolveForViewModelType(typeof(MockView));
            Assert.Equal(typeof(MockViewModel), actual);
        }

        [Fact]
        public void ResolveForViewModelTypeWhenPageOfDifferentAssembly()
        {
            PageNavigationTypeResolver.AssignAssemblies<TestPage, TestPageViewModel>();
            var actual = PageNavigationTypeResolver.ResolveForViewModelType(typeof(TestPage));
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
