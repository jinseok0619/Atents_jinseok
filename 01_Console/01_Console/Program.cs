﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");   // "Hello World"를 출력하는 코드
            //Console.ReadKey();                  // 키 입력 대기하는 코드
            //8/16
            //자기 이름 출력하기
            Console.WriteLine("제이름은 최진석 입니다"); // 출력
            
            //string str = Console.ReadLine(); // 키보드 입력을 박아서 str이라는 string 변수에 저장한다. 입력 

            // 변수 : 변하는 숫자. 컴퓨터에서 사용할 데이터를 저장할 수 있는 곳.
            // 변수의 종류 : 재아토 차입(Data type)
            // int : 인티저, 정수, 소수점 없는 숫자. 32bit
            // float : 플로트, 실수, 소수점 있는 숫자. 32bit
            // string : 스트링, 문자열, 글자들을 저장.
            // bool : 불 불리언, true/false를 저장. 

            int a = 10; // a라는 인티저 변수에 10이라는 데이터를 넣는다.
            long b = 5000000000;    //50억은 int에 넣을수 없다. int는 32비트로 표현가능한 숫자의 갯수는 2^32(4,294,967,296) 개이기 떄문.
            int c = -100;
            int d = 2000000000;
            int e = 2000000000;
            int f = d + e;
            Console.WriteLine(f);


            // float의 단점 : 테셍적으로 오차가 있을 수 밖에 없다.
            float aa = 0.000123f;
            float ab = 0.9999999999999f;
            float ac = 0.0000000000001f;
            float ad = ab + ac; // 결과가 1이 아닐 수도 있다
            Console.WriteLine(ad);

            string str1 = "Hello";
            string str2 = "안녕!";
            string str3 = $"Hello {a}"; //"Hello 10"
            Console.WriteLine(str3);
            string str4 = str1 + str2;  //"Hello안녕!"
            Console.WriteLine(str4);

            bool b1 = true;
            bool b2 = false;

            int level = 1;
            int hp = 10;
            float exp = 0.9f;   //1은 100퍼 0.9는 90퍼
            string name = "너굴맨";

            //너굴맨의 레벨은 1이고 HP는 10이고 exp는 0.9다
            Console.WriteLine($"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}다");
            

            //Console.WriteLine(str);

            Console.ReadKey();              // 키 입력 대기하는 코드
        }
    }
}
