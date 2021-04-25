using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Factories
{
    public static class SoldierFactory
    {
        public static ISoldier CreateSoldier(string[] soldierArgs, List<ISoldier> soldiers)
        {
            string type = soldierArgs[0];
            int id = int.Parse(soldierArgs[1]);
            string firstName = soldierArgs[2];
            string lastName = soldierArgs[3];

            ISoldier soldier = null;

            if (type == "Spy")
            {
                int codeNumber = int.Parse(soldierArgs[4]);
                soldier = new Spy(id, firstName, lastName, codeNumber);
            }
            else
            {
                decimal salary = decimal.Parse(soldierArgs[4]);

                if (type == "Private")
                {
                    soldier = new Private(id, firstName, lastName, salary);

                }
                else if (type == "LieutenantGeneral")
                {
                    int[] privatesIds = soldierArgs.Skip(5).Select(int.Parse).ToArray();

                    List<IPrivate> privates = new List<IPrivate>();

                    foreach (var privateId in privatesIds)
                    {
                        IPrivate current = (IPrivate)soldiers.FirstOrDefault(s => s.Id == privateId);
                        privates.Add(current);
                    }

                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);

                }
                else if (type == "Engineer")
                {
                    Corps corps;
                    bool isParsed = Enum.TryParse<Corps>(soldierArgs[5], out corps);

                    if (isParsed)
                    {
                        string[] repairsArgs = soldierArgs.Skip(6).ToArray();

                        List<IRepair> repairs = new List<IRepair>();

                        for (int i = 0; i < repairsArgs.Length; i += 2)
                        {
                            string repairName = repairsArgs[i];
                            int hoursWorked = int.Parse(repairsArgs[i + 1]);

                            IRepair repair = new Repair(repairName, hoursWorked);

                            repairs.Add(repair);
                        }

                        soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                    }

                    

                }
                else if (type == "Commando")
                {
                    Corps corps;
                    bool isCorpsParsed = Enum.TryParse<Corps>(soldierArgs[5], out corps);

                    if (isCorpsParsed)
                    {
                        string[] missionsArgs = soldierArgs.Skip(6).ToArray();

                        List<IMission> missions = new List<IMission>();

                        for (int i = 0; i < missionsArgs.Length; i += 2)
                        {
                            string missonName = missionsArgs[i];
                            string missionStateString = missionsArgs[i + 1];

                            MissionState missionState;
                            bool isMissionStateParsed = Enum.TryParse<MissionState>(missionStateString, out missionState);

                            if (!isMissionStateParsed)
                            {
                                continue;
                            }

                            IMission mission = new Mission(missonName, missionState);

                            missions.Add(mission);
                        }

                        soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                    }

                }

            }

            return soldier;
        }
    }
}
