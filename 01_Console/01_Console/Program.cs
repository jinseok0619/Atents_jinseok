using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _01_Console
{
    internal class Program
    {
        // 스코프(Scope) : 변수나 함수를 사용할 수 있는 범위. 변수를 선언한 시점에서 해당 변수가 포함된 중괄호가 끝나는 구간까지
        static void Main(string[] args)
        {
            

            // 주말과제용

            //플레이어 만들기
            Human player;
            Console.Write("당신의 이름을 입력해 주세요 : ");    // 이름 입력은 한번만 처리
            string name = Console.ReadLine();

            // 스테이터스 리롤 처리
            string result;
            do
            {
                player = new Human(name);       //스테이터스 랜덤으로 설정
                Console.Write($"이대로 진행하시겠습니까? (Yes/No): "); //yes가 아닌 값이 나오면 다시 실행
                result = Console.ReadLine();
            }
            // while (!(result == "yes" || result == "Yes" || result == "y" || result == "Y"));
            while (result != "yes" && result != "Yes" && result != "y" && result != "Y");

            // 적 만들기
            Orc enemy = new Orc("가로쉬"); // 가로쉬라는 이름으로 오크 만들기

            Console.WriteLine($"{enemy.Name}가 나타났다.");

            Console.WriteLine("\n\n--------------------------------전투시작--------------------------------");

            while( true)    //무한 루프(전투가 끝날때까지. 한명이 죽으면 break로 종료)
            {
                int selection;
                do
                {
                    Console.Write("행동을 선택하세요 ( 1)공격, 2)스킬, 3)방어 )");
                    string temp = Console.ReadLine();   //글자를 받아서
                    int.TryParse(temp, out selection);  // 숫자로 변경  // string 함수를 숫자로 변경 글자와 다른것을 사용하면 0을 출력
                    //selection = int.Parse(temp);  //다른 글자를 사용하여 실행하면 터짐
                } while (selection < 1 || selection > 3);   //1~3사이가 아니면 while을 계속 실행(1~3일때만 종료)
                 //while (selection != 1 && selection !=2 && selection != 3);    //selection이 0보다크고 3보다 크지않으면

                // switch문을 통해 1,2,3 처리
                switch(selection)
                {
                    case 1:
                        player.Attack(enemy); // 1 입력시 Attack 실행
                        break;
                    case 2:
                        player.Skill(enemy); // 2 입력시 Skill 실행
                        break;
                    case 3:
                        player.Defense(); // 3 입력시 Defense 실행
                        break;
                    default:    // 1,2,3이 아닌경우, 코드 구조상 들어오면 안된다.
                        break;
                }


                player.PrintStatus();   //나와 적 스테이터스 실행
                enemy.PrintStatus();    
                if(enemy.IsDead)    //적이 죽으면 승리표시하고 무한루프 종료
                {
                    Console.WriteLine("승리!");
                    break;
                }

                // 적이 안죽었으면 적이 공격 시작
                enemy.Attack(player);       // 적은 그냥 무조건 공격
                player.PrintStatus();   // 나와 적의 상태 표시
                enemy.PrintStatus();    
                if(player.IsDead)           // 내가 죽으면 패배표시허고 무한루프 종료
                {
                    Console.WriteLine("패배!");
                    break;
                }
            }

            Console.ReadKey();                  // 키 입력 대기하는 코드
        }   // Main 함수의 끝

       
    }
}
