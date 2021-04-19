using System;
using System.Security.Cryptography;
using System.Text;

namespace Rotate
{
    class Program
    {

        class HTMLBuilder
        {
            public string html;

            public HTMLBuilder beginTag(string tag)
            {
                this.html += "<" + tag + ">";
                return this;
            }
            public HTMLBuilder endTag(string tag)
            {
                this.html += "</" + tag + ">";
                return this;
            }
            public HTMLBuilder setContent(string content)
            {
                this.html += content;
                return this;
            }
            public string get(string content)
            {
                return this.html;
            }
        }

        static int[] rotate(int[] arr , int count , bool direction)
        {
            count = count % arr.Length;
            int[] result = new int[arr.Length];
            if (!direction)
                count = arr.Length - count%arr.Length;

            for (int i = 0; i < arr.Length; i++)
                result[i] = arr[(arr.Length- count + i) % arr.Length];
            
            return result;
        }
        static void Main(string[] args)
        {
            int[] value = { 1, 2, 3, 4, 5, 6, 7, 8 };
            /**/int[] result = rotate(value, 5,true);

            foreach (var item in rotate(value, 5, true))
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();

            foreach (var item in rotate(value, 2, false))
            {
                Console.Write(item+" ");
            }

            Console.WriteLine();


            //HTML Builder
            HTMLBuilder hb = new HTMLBuilder();
            hb.beginTag("p")
                .setContent("Hello World")
                .endTag("p");




            String val = "Do not use your bag";
            SHA1Managed sha1 = new SHA1Managed();



            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(val));
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
            {
                // can be "x2" if you want lowercase
                sb.Append(b.ToString("X2"));
            }
            Console.WriteLine(sb.ToString().ToLower());
            Console.WriteLine();
        }
    }
}
