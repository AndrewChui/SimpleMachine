using System;
using System.Collections.Generic;


namespace MiniPai
{

    class Register
    {
        public byte Number { get; set; }   //寄存器编号
        public byte Value { get; set; }    //寄存器值
    }

    class Memory
    {
        public byte Address { get; set; }  //内存地址
        public byte Code { get; set; }    //内存的值

    }

    public struct RunInfo
    {
        public int instructionsAccout; //执行的总的指令计数
        public int preAddress;    //上一条指令的地址
        public enum RegMem
        {
            MEMORY,
            REGISTER
        }
        public RegMem regmem;  //是对内存还是对寄存器操作
        public int addressNum;   //本指令地址
    }
    /// <summary>
    /// 指令结构，每条指令占用2个字节
    /// </summary>
    struct Instructions
    {
        public byte highByte; //指令的高字节
        public byte lowByte;  //指令的低字节
    }

    /// <summary>
    /// 指令的解析的结果，根据指令码的不同选择结构字段
    /// </summary>
    struct ParseInstruct
    {
        public byte operationCode;  //指令码，低字节前4位
        public byte regAddress01;   //寄存器号，低字节后4位
        public byte regAddress02;   //寄存器号，高字节前4位
        public byte regAddress03;   //寄存器号，高字节后4位
        public byte memAddress;     //内存地址，高字节；也可能是立即数
    }
    class Machine
    {
        //定义机器的通用寄存器组一共包含16个寄存器
        public static int RegNumber { get; } = 16;
        
        //机器的内存255字节
        public static int MemNumber { get; } = 255;

        //列表数据反应通用寄存器组的情况
        public List<Register> regList = new List<Register>(RegNumber);

        //列表数据反应内存情况
        public List<Memory> memList = new List<Memory>(MemNumber);
       
        public int RegChangeNumber { get; set; }
        
        public RunInfo runInfo;   //机器运行状态数据

        /// <summary>
        /// 构造函数
        /// </summary>
        public Machine()
        {
            //初始化寄存器、内存序号，并置初值为0
            for (int i = 0; i < RegNumber; i++)
            {
                regList.Add(new Register() { Number = (byte)i, Value = 0 });
            }

            for (int i = 0; i < MemNumber; i++)
            {
                memList.Add(new Memory() { Address = (byte)i, Code = 0 });
            }
            runInfo.addressNum = 0;
            runInfo.instructionsAccout = 0;
            runInfo.regmem = RunInfo.RegMem.REGISTER;
            runInfo.preAddress = PCAddress;
            RegChangeNumber = 0;
        }

        //PC寄存器的值
        public byte PCAddress { get; set; } = 0;

        //机器是否处于运行状态
        public bool stopMachine = false;
      

        private ParseInstruct parseInstruct;  //指令解析结果
        private Instructions instructions;  //指令

        /// <summary>
        /// 读取当前指令
        /// </summary>
        public void GetInstructions()
        {
            if (PCAddress >= 0 && PCAddress < 254)
            {
                instructions.lowByte = memList[PCAddress].Code;
                instructions.highByte = memList[PCAddress + 1].Code;
            }
        }
        /// <summary>
        /// 将指令按高4位，低4位解析存储
        /// </summary>
        /// <returns>解析失败返回false</returns>
        public bool ParseInstructions()
        {
            if (instructions.lowByte > 0)
            {
                parseInstruct.operationCode = (byte)((instructions.lowByte & 0xF0) >> 4);  //高4位
                parseInstruct.regAddress01 = (byte)(instructions.lowByte & 0x0F);   //低4位
                parseInstruct.regAddress02 = (byte)((instructions.highByte & 0xF0) >> 4);  //高4位
                parseInstruct.regAddress03 = (byte)(instructions.highByte & 0x0F);  //低4位
                parseInstruct.memAddress = instructions.highByte;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 执行指令
        /// </summary>
        /// <returns>成功返回true，失败返回false</returns>
        public bool RunInstructions()
        {
            runInfo.preAddress = PCAddress;   //存储当前指令地址
            switch (parseInstruct.operationCode)
            {
                case 1:   
                    regList[parseInstruct.regAddress01].Value = memList[parseInstruct.memAddress].Code;
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.REGISTER;
                    runInfo.addressNum = parseInstruct.regAddress01;
                    PCAddress += 2;
                    break;
                case 2:
                    regList[parseInstruct.regAddress01].Value = parseInstruct.memAddress;
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.REGISTER;
                    runInfo.addressNum = parseInstruct.regAddress01;
                    PCAddress += 2;
                    break;
                case 3:
                    memList[parseInstruct.memAddress].Code = regList[parseInstruct.regAddress01].Value;
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.MEMORY;
                    runInfo.addressNum = parseInstruct.memAddress;
                    PCAddress += 2;
                    break;
                case 4:
                    regList[parseInstruct.regAddress03].Value = regList[parseInstruct.regAddress02].Value;
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.REGISTER;
                    runInfo.addressNum = parseInstruct.regAddress03;
                    PCAddress += 2;
                    break;
                case 5:
                    sbyte sbyteReg01 = (sbyte)regList[parseInstruct.regAddress02].Value;
                    sbyte sbytereg02 = (sbyte)regList[parseInstruct.regAddress03].Value;
                    sbyte result = (sbyte)(sbyteReg01 + sbytereg02);
                    regList[parseInstruct.regAddress01].Value = (byte)result;
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.REGISTER;
                    runInfo.addressNum = parseInstruct.regAddress01;
                    PCAddress += 2;
                    break;
                case 6:
                    float reg02 = ParseFloat(regList[parseInstruct.regAddress02].Value);
                    float reg03 = ParseFloat(regList[parseInstruct.regAddress03].Value);
                    float reg01 = reg02 + reg03;
                    regList[parseInstruct.regAddress01].Value = (byte)reg01;
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.REGISTER;
                    runInfo.addressNum = parseInstruct.regAddress01;
                    PCAddress += 2;
                    break;
                case 7:
                    regList[parseInstruct.regAddress01].Value =
                     (byte)(regList[parseInstruct.regAddress02].Value | regList[parseInstruct.regAddress03].Value);
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.REGISTER;
                    runInfo.addressNum = parseInstruct.regAddress01;
                    PCAddress += 2;
                    break;
                case 8:
                    regList[parseInstruct.regAddress01].Value =
                     (byte)(regList[parseInstruct.regAddress02].Value & regList[parseInstruct.regAddress03].Value);
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.REGISTER;
                    runInfo.addressNum = parseInstruct.regAddress01;
                    PCAddress += 2;
                    break;
                case 9:
                    regList[parseInstruct.regAddress01].Value =
                    (byte)(regList[parseInstruct.regAddress02].Value ^ regList[parseInstruct.regAddress03].Value);
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.REGISTER;
                    runInfo.addressNum = parseInstruct.regAddress01;
                    PCAddress += 2;
                    break;
                case 0xA:
                    regList[parseInstruct.regAddress01].Value =
                       (byte)(regList[parseInstruct.regAddress01].Value >> parseInstruct.regAddress02);
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.REGISTER;
                    runInfo.addressNum = parseInstruct.regAddress01;
                    PCAddress += 2;
                    break;
                case 0xB:
                    if (regList[parseInstruct.regAddress01].Value == regList[0].Value)
                    {
                        PCAddress = parseInstruct.memAddress;
                    }
                    else
                    {
                        PCAddress += 2;
                    }
                    break;
                case 0xC:
                    stopMachine = true;
                    PCAddress += 2;
                    break;
            }
            return true;
        }

        private float ParseFloat(byte regByte)
        {
            float rearNumber = (float)(regByte & 0x0F);
            while (rearNumber >= 1)
            {
                rearNumber = rearNumber / 10;
            }
            int exp = (regByte & 0x70) >> 4;
            exp = 7 - exp;
            float num = (float)(rearNumber * Math.Pow(2, exp));
            if ((regByte & 0x80) == 0)
            {
                return num;
            }
            else
            {
                return -num;
            }
        }
    }
}
