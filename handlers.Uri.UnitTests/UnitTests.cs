﻿using System;
using System.IO;
using NUnit.Framework;
using Synapse.Core;

namespace handlers.Uri.UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [OneTimeSetUp]
        public void Init()
        {
            Directory.SetCurrentDirectory( Path.Combine( System.Reflection.Assembly.GetExecutingAssembly().Location, @"..\..\..\Files" ) );
        }

        [Test]
        [Category( "File" )]
        [TestCase( "yaml_in.yaml", ReturnFormat.Yaml )]
        [TestCase( "json_in.json", ReturnFormat.Json )]
        [TestCase( "xml_in.xml", ReturnFormat.Xml )]
        public void FileAsLocalPath(string file, ReturnFormat format)
        {
            UriStubHandler handler = new UriStubHandler();
            string uri = Path.Combine( Environment.CurrentDirectory, file );

            UriStubHandlerParameters parms = new UriStubHandlerParameters() { Uri = uri, Format = format };
            string result = handler.GetFileUri( parms.ParsedUri.ToString() );

            object o = handler.FormatData( result, parms.Format );
        }

        [Test]
        [Category( "File" )]
        [TestCase( "yaml_in.yaml", ReturnFormat.Yaml )]
        [TestCase( "json_in.json", ReturnFormat.Json )]
        [TestCase( "xml_in.xml", ReturnFormat.Xml )]
        public void FileAsUncPath(string file, ReturnFormat format)
        {
            UriStubHandler handler = new UriStubHandler();
            string uri = $@"\\{Environment.MachineName}\" + Path.Combine( Environment.CurrentDirectory, file ).ToLower().Replace( "c:", "c$" );

            UriStubHandlerParameters parms = new UriStubHandlerParameters() { Uri = uri, Format = format };
            string result = handler.GetFileUri( parms.ParsedUri.ToString() );

            object o = handler.FormatData( result, parms.Format );
        }

        [Test]
        [Category( "File" )]
        [TestCase( "yaml_in.yaml", ReturnFormat.Yaml )]
        [TestCase( "json_in.json", ReturnFormat.Json )]
        [TestCase( "xml_in.xml", ReturnFormat.Xml )]
        public void FileAsUriPath(string file, ReturnFormat format)
        {
            UriStubHandler handler = new UriStubHandler();
            string uri = $"file://" + Path.Combine( Environment.CurrentDirectory, file );

            UriStubHandlerParameters parms = new UriStubHandlerParameters() { Uri = uri, Format = format };
            string result = handler.GetFileUri( parms.ParsedUri.ToString() );

            object o = handler.FormatData( result, parms.Format );
        }
    }
}