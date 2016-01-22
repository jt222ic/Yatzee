﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model
{
    [Serializable]
    class DAL
    {
        private static readonly string _FILE_PATH = "Listan.bin";      //refrens https://www.youtube.com/watch?v=URw86vBWeGE

        private static List<Player> memberList = new List<Player>();

        public static void SaveToFile()                                                 // referens för användning av Serialized 
        {
            using (FileStream fileStream = new FileStream(_FILE_PATH, FileMode.OpenOrCreate))             // object som ska sparas i fil
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(fileStream, memberList);
                fileStream.Close();
            }
        }
        public static void AddMemberToList(Player member)
        {
            memberList.Add(member);
        }

        public static IReadOnlyCollection<Player> getMemberList()
        {

            return memberList.AsReadOnly();

        }
    }
}