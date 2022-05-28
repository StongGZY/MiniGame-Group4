using System;

enum LandformType { Camp, Mine, Powerplant, Mist, ResearchStation, Forest, Aquatic};

public class Landform
{
	int _extraMovePower;
	LandformType _type;
	String _statement;

	public Landform(int extraMovePower, LandformType type,String statement)
	{
		_extraMovePower = extraMovePower;
		_type = type;
		_statement = statement;

	}

	public LandformType GetLandformType()
    {
		return _type;
    }

	public int GetextraMovePower()
    {
		return _extraMovePower;
    }

	public String Getstatement()
    {
		return _statement;

	}

}

public class Test
{
	

	static void Main()
	{
		LandformType type = LandformType.Camp;
		Landform sb(1,type,"12121");
		Console.WriteLine(sb.Getstatement());
	
	}
}

namespace HelloWorldApplication
{
	class HelloWorld
	{
		static void Main(string[] args)
		{
			/* 我的第一个 C# 程序*/
			Console.WriteLine("Hello World");
			Console.ReadKey();
		}
	}
}