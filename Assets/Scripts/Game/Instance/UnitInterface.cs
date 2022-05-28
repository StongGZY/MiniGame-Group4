using System;

interface UnitInterface
{

	void Move();  //单位移动


	void ReceiveDamge(int damage);  //单位受到伤害

	int GetHP();

	int GetHPlimit();

	int GetHPRecovery();


	void CostEnergy(int energy);

	int GetEnergy();

	int GetEnergyLimit();

	int GetEnergyRecovery();



	int GetPhysicalDamage();

	int GetPhysicalResistance();

	int GetPsionicDamage();

	int GetPsionicResistance();


	void CostMovePower(int movepower);

	int GetMovePower();

	int GetMovePowerLimit();


	int GetSight();




}
