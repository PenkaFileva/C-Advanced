﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.The_Heigan_Dance
{
    class Program
    {
        private const int ChemberSize = 15;
        private const int CloudDamage = 3500;
        private const int EruptionDamage = 6000;
        private const double PlayerHealth = 18500;
        private const double HeiganHealth = 3000000;

        static void Main(string[] args)
        {
            var playerPos = new int[] {ChemberSize / 2, ChemberSize / 2};
            var damageToHeigan = double.Parse(Console.ReadLine());
            var heiganPoints = HeiganHealth;
            var playerPoints = PlayerHealth;
            var isHeiganDead = false;
            var isPlayerDead = false;
            var hasCloud = false;
            var deathCause = "";

            while (true)
            {
                var spellTokens = Console.ReadLine().Split();
                var spell = spellTokens[0];
                var spellRow = int.Parse(spellTokens[1]);
                var spellCol = int.Parse(spellTokens[2]);

                heiganPoints -= damageToHeigan;
                isHeiganDead = heiganPoints <= 0;
                if (hasCloud)
                {
                    playerPoints -= CloudDamage;
                    isPlayerDead = playerPoints <= 0;
                }
                if (isHeiganDead || isPlayerDead)
                {
                    break;
                }
                if (IsPlayerInDamageZone(playerPos, spellRow, spellCol))
                {
                    if (!PlayerTryEscape(playerPos, spellRow, spellCol))
                    {
                        switch (spell)
                        {
                            case "Cloud": playerPoints -= CloudDamage;
                                hasCloud = true;
                                deathCause = "Plague Cloud";
                                break;
                            case "Eruption": playerPoints -= EruptionDamage;
                                deathCause = spell;
                                break;
                        }
                    }   
                }
                isPlayerDead = playerPoints <= 0;
                if (isPlayerDead)
                {
                    break;
                }
            }
            PrintResult(playerPos, heiganPoints, playerPoints, deathCause);
        }

        private static void PrintResult(int[] playerPos, double heiganPoints, double playerPoints, string deathCause)
        {
            if (heiganPoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganPoints:f2}");
            }
            if (playerPoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {deathCause}");
            }
            else
            {
                Console.WriteLine($"Player: {playerPoints}");
            }
            Console.WriteLine($"Final position: {playerPos[0]}, {playerPos[1]}");
        }

        private static bool PlayerTryEscape(int[] playerPos, int spellRow, int spellCol)
        {
            if (playerPos[0]-1 >= 0 && playerPos[0] -1 < spellRow-1)
            {
                playerPos[0]--;
                return true;
            }
            else if (playerPos[1] +1 < ChemberSize && playerPos[1]+1 > spellCol+1)
            {
                playerPos[1]++;
                return true;
            }
            else if (playerPos[0] +1 < ChemberSize && playerPos[0] +1 > spellRow +1)
            {
                playerPos[0]++;
                return true;
            }
            else if(playerPos[1] -1 >=0 && playerPos[1] -1 < spellCol -1)
            {
                playerPos[1]--;
                return true;
            }
            return false;
        }

        private static bool IsPlayerInDamageZone(int[] playerPos, int spellRow, int spellCol)
        {
            bool isHitRow = playerPos[0] >= spellRow - 1 && playerPos[0] <= spellRow + 1;
            bool isHitCol = playerPos[1] >= spellCol - 1 && playerPos[1] <= spellCol + 1;
            return isHitRow && isHitCol;
        }
    }
}
