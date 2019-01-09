﻿using System.Text;
using Xunit;

namespace Ezreal.SDK.ShouQianBa.Test.Security
{
    public class MD5HashTest
    {
        [Theory]
        [InlineData("123456", "UTF-8")]
        [InlineData("123456", "ASCII")]
        public void Md5HashToBase64(string value, string encoding = nameof(Encoding.UTF8))
        {
            string x = ShouQianBa.Security.MD5Hash.Md5HashToBase64(value, encoding);
            Assert.NotEmpty(x);
        }

        [Theory]
        [InlineData("123456", "UTF-8")]
        [InlineData("123456", "ASCII")]
        public void Md5HashToHex(string value, string encoding = nameof(Encoding.UTF8))
        {
            string x = ShouQianBa.Security.MD5Hash.Md5HashToHex(value, encoding);
            Assert.NotEmpty(x);
        }
    }
}