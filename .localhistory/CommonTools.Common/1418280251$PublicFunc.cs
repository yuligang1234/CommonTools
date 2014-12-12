﻿
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Web.Security;

namespace CommonTools.Common
{
    public static class PublicFunc
    {

        #region 基础

        /// <summary>
        ///  获取指定字符串的长度
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="start">开始位置</param>
        /// <param name="length">长度</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-12-10 15:24:47
        public static string SubstringValue(this string value, int start, int length)
        {
            return value.Trim().Substring(start, length);
        }

        #endregion


        #region 类型转换

        /// <summary>
        ///  string转换成int,-2表示转换失败
        /// </summary>
        /// <param name="str">string</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-12-10 11:09:00
        public static int ConvertToInt(this string str)
        {
            int i;
            if (!int.TryParse(str, out i))
            {
                i = -2;
            }
            return i;
        }

        #endregion

        #region 加解密

        /// <summary>
        ///  MD5加密
        /// </summary>
        /// <param name="value">明文</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-12-10 11:29:05
        public static string GetMd5(this string value)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            string bits = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(value)));
            return bits.Replace("-", PublicFields.Md5Replace);
        }

        /// <summary>
        ///  SHA1加密
        /// </summary>
        /// <param name="value">明文</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-12-10 15:25:52
        public static string GetSha1(this string value)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string bits = BitConverter.ToString(sha1.ComputeHash(Encoding.Default.GetBytes(value)));
            return bits.Replace("-", PublicFields.Sha1Replace);
        }

        /// <summary>
        ///  DES加密
        /// </summary>
        /// <param name="value">明文</param>
        /// <param name="key">密钥</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-12-11 13:44:46
        public static string EncrypteDes(this string value, string key)
        {
            object obj = new object();
            byte[] mbtIv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            DESCryptoServiceProvider mDesProvider = new DESCryptoServiceProvider();
            byte[] mbtEncryptString = Encoding.Default.GetBytes(value);
            MemoryStream mstream = new MemoryStream();
            CryptoStream mcstream = new CryptoStream(mstream, mDesProvider.CreateEncryptor(Encoding.Default.GetBytes(key), mbtIv), CryptoStreamMode.Write);
            mcstream.Write(mbtEncryptString, 0, mbtEncryptString.Length);
            mcstream.FlushFinalBlock();
            string mstrEncrypt = Convert.ToBase64String(mstream.ToArray());
            mstream.Close(); mstream.Dispose();
            mcstream.Close(); mcstream.Dispose();
            return mstrEncrypt;
        }

        /// <summary>
        ///  DES解密
        /// </summary>
        /// <param name="value">密文</param>
        /// <param name="key">密钥</param>
        /// Author  : 俞立钢
        /// Company : 绍兴标点电子技术有限公司
        /// Created : 2014-12-11 14:31:15
        public static string DecrypteDes(this string value, string key)
        {

        }

        #endregion



    }
}