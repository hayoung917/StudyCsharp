using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalShopApp2020
{
    public enum BaseMode
    {
        NONE,   //아무것도 아닌 상태(기본상태)
        INSERT, //입력
        UPDATE, //수정
        DELETE,
        SELECT
    }
    public class Commons
    {
        public static string USERID = string.Empty;
        //공통 DB 연결 문자열
        public static readonly string CONNSTR =
           "Data Source = localhost;" +
           "Port=3306;" +
           "Database=bookrentalshop;" +
           "Uid=root;" +
           "Password=mysql_p@ssw0rd";

        /// <summary>
        /// MD5 암호화 메서드
        /// </summary>
        /// <param name="md5Hash">해시키값</param>
        /// <param name="input">평문</param>
        /// <returns>암호화된 문자열</returns>
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sbuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                //16진수로 변환
                sbuilder.Append(data[i].ToString("x2"));
            }

            return sbuilder.ToString();
        }
    }

    
}
