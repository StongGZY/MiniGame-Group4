using System;


interface TileInterface
{
	int GetYield(int yieldIndex);

	int GetYieldReserve(int yieldIndex);

	void ReduceYieldReserve(int yieldIndex, int amount);

	Landform GetLandform();

	int getTileType();

}
