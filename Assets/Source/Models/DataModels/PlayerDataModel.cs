﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class PlayerDataModel : DataModel
{
    public static PlayerDataModel Data;
    public int CompletedLevelCount = 1;
    public int Level = 1;
    public int LevelIndex;
    public int Money = 100;

    public PlayerDataModel Load()
    {
        if (Data == null)
        {
            Data = this;
            object data = LoadData();

            if (data != null)
            {
                Data = (PlayerDataModel)data;
            }
        }

        return Data;
    }


    public void Save()
    {
        Save(Data);
    }
}