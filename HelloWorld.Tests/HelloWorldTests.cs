using NSubstitute;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using HelloWorld.Models;

namespace HelloWorld.Tests
{

    /// <summary>
    /// Test classes for hello world
    /// </summary>
    [TestClass]
    public class HelloWorldTests
    {

        #region Properties

        /// <summary>
        /// The hello world we are testing
        /// </summary>
        private Core.HelloWorld HelloWorldLogic { get; set; }

        /// <summary>
        /// The hello world we are testing
        /// </summary>
        private IHelloWorldParameters HelloWorldParam { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Initalizing our test class values
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.HelloWorldParam = Substitute.For<IHelloWorldParameters>();
            this.HelloWorldLogic = new Core.HelloWorld(new StringWriter(), this.HelloWorldParam);
        }

        /// <summary>
        /// Testing we can write hello world..
        /// </summary>
        [TestMethod]
        public void HelloWorld_ReturnsHelloWorld()
        {
            Assert.AreEqual("Hello World.", this.HelloWorldLogic.GetHelloWorld());
        }

        #endregion

    }
}
