using HelloWorld.Models;
using System;
using System.IO;

namespace HelloWorld.Core
{

    /// <summary>
    /// Class which prints hello world to a given location
    /// </summary>
    public class HelloWorld
    {

        #region Constants, Enums, and Variables

        /// <summary>
        /// String writer to write our precious hello world
        /// </summary>
        private readonly StringWriter StringMaker;

        #endregion

        #region Properties

        /// <summary>
        /// The parameters for our hello world printer
        /// </summary>
        private IHelloWorldParameters PrintParameters { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creating a new instance of HelloWorld -injecting dependencies
        /// </summary>
        public HelloWorld(StringWriter stringWriter,
                          IHelloWorldParameters printParameters)
        {
            this.StringMaker = stringWriter;
            this.PrintParameters = printParameters;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns hello world string
        /// </summary>
        /// <returns></returns>
        public string GetHelloWorld()
        {
            return "Hello World.";
        }

        /// <summary>
        /// Writes hello world to console
        /// </summary>
        public void PrintHelloWorld()
        {
            Console.WriteLine(GetHelloWorld());
        }

        /// <summary>
        /// Writing hello world to a text file in a given location
        /// </summary>
        public void HelloWorldTextFile()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}