﻿namespace pkm3dsRNG
{
    public abstract class IPKM
    {
        public GameVersion Version { get; set; } = GameVersion.Any;
        public short Species { get; set; }
        public byte Form { get; set; }

        public byte Ability { get; set; }
        public byte Nature { get; set; }
        public byte Gender { get; set; }

        public int[] IVs { get; set; }
        public byte Level { get; set; }

        public PKHeX.Core.PersonalInfo info => GameVersion.Gen6.Contains(Version) ? PersonalTable.ORAS.getFormeEntry(Species, Form) : PersonalTable.SM.getFormeEntry(Species, Form);
        public bool IV3 => info.EggGroups[0] == 0xF;
        public byte GenderRatio => (byte)(Gender > 0 ? 2 - 2 * Gender : info.Gender); // 1/2 => 0/254
        public bool IsRandomGender => FuncUtil.IsRandomGender(GenderRatio);
        public byte SettingGender => FuncUtil.getGenderRatio(GenderRatio);
    }
}
