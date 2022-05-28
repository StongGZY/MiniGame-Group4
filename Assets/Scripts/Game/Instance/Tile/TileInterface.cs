using System;
using Landform


interface TileInterface
{
	int GetYield(int yieldIndex);

	int GetYieldReserve(int yieldIndex);

	void ReduceYieldReserve(int yieldIndex, int amount);

	int getTileType();

}
