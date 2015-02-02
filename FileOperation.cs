﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanCoding
{
    class FileOperation
    {
        public string fileName;
        public FileOperation(string fileName)
        {
            this.fileName = fileName;
        }
        public void appendTo(string content, string fileName)
        {
            StreamWriter file;
            file = File.AppendText(fileName);
            file.Write(content);
            file.Close();
        }
        public void writeNew(string content, string fileName)
        {
            StreamWriter file = new StreamWriter(fileName);
            file.Write(content);
            file.Close();

        }
        public string readFrom(string fileName)
        {
            StreamReader readFile = File.OpenText(fileName);
            string content = readFile.ReadLine();
            string getLine = " ";
            while (getLine != null)
            {
                content += getLine;
                getLine = readFile.ReadLine();
            }
            readFile.Close();
            return content;

        }
        public string readFrom()
        {
            StreamReader readFile = File.OpenText(fileName);
            string content = readFile.ReadLine();
            string getLine = " ";
            while (getLine != null)
            {
                content += getLine;
                getLine = readFile.ReadLine();
            }
            readFile.Close();
            return content;

        }

    }
}
