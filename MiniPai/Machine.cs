using System;
using System.Collections.Generic;

/// <summary>
///机器体系结构：
///这种机器有16个通用寄存器，编号为0 ~F(十六进制表示）。每个寄存器的长度为1字节（8位）。
///为了在指令中标识寄存器，每个寄存器被赋予了唯一的4位二进制模式，用于代表其寄存器号。
///于是，寄存器0由0000(十六进制0)标识，寄存器4由0100(十六进制4)标识。
///机器主存中有256个单元，每个单元被赋予一个范围为0 ~255的整数地址。因此，一个地址
///可以由00000000~11111111(或者是十六进制值的00~FF)的一个8位二进制模式来表示。
/// </summary>
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
    /// <summary>
    /// 每条机器指令都是2字节长：前面的4位是操作码，后面的12位组成操作数字段。
    /// </summary>

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
            //下面用十六进制记数法表示的指令及简要说明。字母R、S及T在表示寄存器标识符的那些
            //字段处用来替代十六进制数字，并且因指令的具体应用而异。字母X及Y用来在变量字段替代十
            //六进制数字，而不是代表寄存器。
            //指令用CRXY的形式表示，其中C是指令码
            switch (parseInstruct.operationCode)
            {
           
                case 1:
                    //指令：1RXY
                    //在地址为XY的存储单元中找到的二进制数加载（LOAD)到寄存器R
                    //例：14A3将使得地址为A3的存储单元的内容放入寄存器4

                    regList[parseInstruct.regAddress01].Value = memList[parseInstruct.memAddress].Code;
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.REGISTER;
                    runInfo.addressNum = parseInstruct.regAddress01;
                    PCAddress += 2;
                    break;

                case 2:
                    //指令：2RXY
                    //将二进制数XY存入（LOAD)寄存器R
                    //例：20A3将使得值A3放入寄存器0

                    regList[parseInstruct.regAddress01].Value = parseInstruct.memAddress;
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.REGISTER;
                    runInfo.addressNum = parseInstruct.regAddress01;
                    PCAddress += 2;
                    break;

                case 3:
                    //指令： 3RXY
                    //将寄存器R中的位模式存储（STORE)在地址为XY的存储单元中
                    //例：35B1将使得寄存器5中的内容放入地址为B1的存储单元

                    memList[parseInstruct.memAddress].Code = regList[parseInstruct.regAddress01].Value;
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.MEMORY;
                    runInfo.addressNum = parseInstruct.memAddress;
                    PCAddress += 2;
                    break;

                case 4:
                    //指令： 40RS
                    //将寄存器R中的值复制到寄存器S
                    //40A4将使得寄存器A的内容复制到寄存器4

                    regList[parseInstruct.regAddress03].Value = regList[parseInstruct.regAddress02].Value;
                    runInfo.instructionsAccout++;
                    runInfo.regmem = RunInfo.RegMem.REGISTER;
                    runInfo.addressNum = parseInstruct.regAddress03;
                    PCAddress += 2;
                    break;
                case 5:
                    //指令： 5RST
                    //将寄存器S及寄存器T的位模式作为二进制补码表示相加（ADD),将求
                    //和结果存放在寄存器R中
                    //例：5726将使得寄存器2和寄存器6中的二进制数值相加，并将和存放在
                    //寄存器7中

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
                    //指令： 6RST
                    //将寄存器S及寄存器T的位模式作为浮点表示值相加（ADD),并将浮点
                    //结果存放在寄存器R中
                    //例：634E将使得寄存器4和寄存器E中的浮点值相加，并将结果存放在寄
                    //存器3中

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
                    //指令： 7RST
                     
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
