using System;
using NextGateForPrism.Tests.ViewModels;
using NextGateForPrism.Tests.Views;
using Xunit;

namespace NextGateForPrism.Tests
{
    public class PageNavigationTypeResolverFixture
    {
        public PageNavigationTypeResolverFixture()
        {
            PageNavigationTypeResolver.Clear();
        }

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

        [Fact]
        public void ResolveForViewTypeWhenViewOfSameAssembly()
        {
            var actual = PageNavigationTypeResolver.ResolveForViewType<MockViewModel>();
            Assert.Equal(typeof(MockView), actual);
        }

        [Fact]
        public void ResolveForViewTypeWhenPageOfSameAssembly()
        {
            var actual = PageNavigationTypeResolver.ResolveForViewType<MockPageViewModel>();
            Assert.Equal(typeof(MockPage), actual);
        }

        [Fact]
        public void ResolveForViewTypeWhenDifferentAssembly()
        {
            PageNavigationTypeResolver.AssignAssemblies<TestPage, TestPageViewModel>();
            var actual = PageNavigationTypeResolver.ResolveForViewType<TestPageViewModel>();
            Assert.Equal(typeof(TestPage), actual);
        }

        [Fact]
        public void Clear()
        {
            PageNavigationTypeResolver.AssignAssemblies<TestPage, TestPageViewModel>();
            PageNavigationTypeResolver.Clear();

            Assert.Null(PageNavigationTypeResolver.ResolveForViewModelType(typeof(TestPage)));
            Assert.Null(PageNavigationTypeResolver.ResolveForViewType<TestPageViewModel>());
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
