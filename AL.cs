using IWshRuntimeLibrary;
using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AL
{
    /// <summary>
    /// Хранит методы ALEX ALL
    /// </summary>
    class AL
    {
        [DllImport("wininet.dll")] private static extern bool InternetGetConnectedState(out int Description, int ReservedValue);


        /// <summary>
        /// Создаёт правило Брандмауэра
        /// </summary>
        /// <param name="Ports"> Укажите один порт, либо диапазон в формате FirstRangePoint-SecondRangePoint</param>
        /// <param name="Name"> Укажите название Правила Брандмауэра</param>
        /// <param name="Description"> Укажите описание правила</param>
        /// <param name="Direction"> Укажите направление правила:
        /// in — для входящих подключений
        /// out — для исходящих подключений
        /// </param>
        /// <param name="Protocol"> Укажите название протокола для блокировки (TCP UDP ICMPv4 ICMPv6)</param>
        /// <param name="Action">Allow or Block</param>
        /// 
        public void AddFirewallRule(string Name, string Direction, string Ports, string Protocol = "TCP", string Action = "Block", string Description = "")
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;

            // Let's create a new rule
            INetFwRule2 inboundRule = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            inboundRule.Enabled = true;
            //Allow through firewall
            if (Direction == "out")
            {
                inboundRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            }
            else
            {
                inboundRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
            }
            if (Action == "Block")
            {
                inboundRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            }
            else
            {
                inboundRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            }
            //Using protocol TCP

            // NET_FW_IP_PROTOCOL_TCP = 6
            // NET_FW_IP_PROTOCOL_UDP = 17
            // NET_FW_IP_PROTOCOL_ICMPv4 = 1
            // NET_FW_IP_PROTOCOL_ICMPv6 = 58
            if (Protocol == "TCP")
            {
                inboundRule.Protocol = 6; // TCP
            }
            if (Protocol == "UDP")
            {
                inboundRule.Protocol = 17; // UDP
            }
            if (Protocol == "ICMPv4")
            {
                inboundRule.Protocol = 1; // ICMPv4
            }
            if (Protocol == "ICMPv6")
            {
                inboundRule.Protocol = 58; // ICMPv6
            }
            else
            {
                inboundRule.Protocol = 6; // TCP
            }

            inboundRule.RemotePorts = Ports;


            //Name of rule
            inboundRule.Name = Name;
            // ...//


            inboundRule.Profiles = currentProfiles;

            inboundRule.Description = Description;
            // Now add the rule
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Add(inboundRule);
        }


        /// <summary>
        /// Удаляет правило из брандмауэра
        /// </summary>
        /// <param name="Name"></param>
        public void RemoveFirewallRule(string Name)
        {
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
        Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Remove(Name);
        }

        /// <summary>
        /// Проверяет, есть ли подключение к интернету
        /// </summary>
        /// <returns></returns>
        public bool CheckInternetConnect()
        {
            int D;
            if (InternetGetConnectedState(out D, 0).ToString() == "True")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Проверяет наличие правила в Брандмауэре по различным параметрам
        /// </summary>
        /// <param name="Name">Название правила</param>
        /// <param name="Direction">Укажите направление правила:
        /// in — для входящих подключений
        /// out — для исходящих подключений</param>
        /// <param name="Ports">Укажите один порт, либо диапазон в формате FirstRangePoint-SecondRangePoint</param>
        /// <param name="Protocol">Укажите название протокола для блокировки (TCP UDP ICMPv4 ICMPv6)</param>
        /// <param name="Action">Allow or Block</param>
        /// <param name="Description"> Укажите описание правила</param>
        /// <returns></returns>
        public bool CheckFirewallRule(string Name, string Direction = "", string Ports = "", string Protocol = "", string Action = "", string Description = "")
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            bool ret1 = true;
            bool ret2 = true;
            bool ret3 = true;
            bool ret4 = true;
            bool ret5 = true;
            bool ret6 = true;
            bool R = false;
            try
            {
                if (fwPolicy2.Rules.Item(Name).Enabled == true)
                    ret1 = true;
                else
                    ret1 = false;


                if (Direction.Length > 0)
                {
                    if (Direction == "in" &&
                        fwPolicy2.Rules.Item(Name).Direction == NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN)
                    {
                        ret2 = true;
                    }
                    else
                    {
                        if (Direction == "out" &&
                        fwPolicy2.Rules.Item(Name).Direction == NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT)
                        {
                            ret2 = true;
                        }
                        else
                        {
                            ret2 = false;
                        }
                    }
                }

                if (Ports.Length > 0)
                {
                    if (fwPolicy2.Rules.Item(Name).RemotePorts == Ports)
                    {
                        ret3 = true;

                    }
                    else
                    {
                        ret3 = false;
                    }
                }


                if (Protocol.Length > 0)
                {
                    if (fwPolicy2.Rules.Item(Name).Protocol == 6 &&
                        Protocol == "TCP")
                    {
                        ret4 = true;
                    }
                    else
                    {
                        if (fwPolicy2.Rules.Item(Name).Protocol == 17 &&
                        Protocol == "UDP")
                        {
                            ret4 = true;
                        }
                        else
                        {
                            if (fwPolicy2.Rules.Item(Name).Protocol == 1 &&
                            Protocol == "ICMPv4")
                            {
                                ret4 = true;
                            }
                            else
                            {
                                if (fwPolicy2.Rules.Item(Name).Protocol == 58 &&
                                Protocol == "ICMPv6")
                                {
                                    ret4 = true;
                                }
                                else
                                {
                                    ret4 = false;
                                }
                            }
                        }
                    }
                }


                if (Action.Length > 0)
                {
                    if (fwPolicy2.Rules.Item(Name).Action == NET_FW_ACTION_.NET_FW_ACTION_ALLOW &&
                        Action == "Allow")
                    {
                        ret5 = true;
                    }
                    else
                    {
                        if (fwPolicy2.Rules.Item(Name).Action == NET_FW_ACTION_.NET_FW_ACTION_BLOCK &&
                        Action == "Block")
                        {
                            ret5 = true;
                        }
                        else
                        {
                            ret5 = false;
                        }
                    }
                }

                if (Description.Length > 0)
                {
                    if (fwPolicy2.Rules.Item(Name).Description == Description)
                    {
                        ret6 = true;
                    }
                    else
                    {
                        ret6 = false;
                    }
                }
                if (ret1 == true &&
                    ret2 == true &&
                    ret3 == true &&
                    ret4 == true &&
                    ret5 == true &&
                    ret6 == true)
                {
                    R = true;
                }
                else
                {
                    R = false;
                }
            }
            catch (Exception)
            {
                R = false;
            }
            return R;
        }


        /// <summary>
        /// Добавляет к числу минут слово в правильном падеже
        /// </summary>
        /// <param name="Number"> Число, к которому нужно приставить слово с падежом</param>
        /// <param name="ShowInt"> Число + слово</param>
        /// <returns></returns>
        public string Minute(int Number)
        {
            string str;
            if ((Number % 10 == 0) || (Number % 10 >= 5) || ((Number / 10) % 10 == 1))
                str = Number.ToString() + " минут";
            else if (Number % 10 == 1)
                str = Number.ToString() + " минута";
            else
                str = Number.ToString() + " минуты";
            return str;
        }

        /// <summary>
        /// Шифрует строку простейшим алогритмом
        /// </summary>
        /// <param name="str"> Строка для шифрования</param>
        /// <returns></returns>
        public string Encoding(string str)
        {
            char[] mas = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                int code1, code3 = 0;
                List<int> code2 = new List<int>();
                int index = 2;
                code1 = (int)str[i];
                while (code1 > 0)
                {
                    if (code1 % index == 0)
                    {
                        index = index * 2;
                        code2.Add(0);
                    }
                    else
                    {
                        code1 = code1 - index / 2;
                        code2.Add(1);
                        index = index * 2;
                    }
                }
                if (code2[0] == 0)
                {
                    for (int j = 0; j < code2.Count; j++)
                    {
                        if (code2[j] == 0)
                            code2[j] = 1;
                        else
                            code2[j] = 0;
                    }
                }
                index = 1;
                for (int j = code2.Count - 1; j >= 0; j--)
                {
                    code3 = code3 + code2[j] * index;
                    index = index * 2;
                }
                if (code3 < 32768)
                    mas[i] = (char)(code3 + i % 4);
                else
                    mas[i] = str[i];
                code2.Clear();
            }
            string str2 = "";
            for (int i = 0; i < str.Length; i++)
                str2 = str2 + mas[i];
            return str2;
        }

        /// <summary>
        /// Декодирует строку простейшим алгоритмом
        /// </summary>
        /// <param name="str"> Строка для дешифровки</param>
        /// <returns></returns>
        public string Decoding(string str)
        {
            char[] mas = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                int code1, code3 = 0;
                int index = 2;
                List<int> code2 = new List<int>();
                code1 = (int)str[i] - i % 4;
                while (code1 > 0)
                {
                    if (code1 % index == 0)
                    {
                        code2.Add(0);
                        index = index * 2;
                    }
                    else
                    {
                        code2.Add(1);
                        code1 = code1 - index / 2;
                        index = index * 2;
                    }
                }
                if (code2[0] == 0)
                {
                    for (int j = 0; j < code2.Count; j++)
                    {
                        if (code2[j] == 0)
                            code2[j] = 1;
                        else
                            code2[j] = 0;
                    }
                }
                index = 1;
                for (int j = code2.Count - 1; j >= 0; j--)
                {
                    code3 = code3 + code2[j] * index;
                    index = index * 2;
                }
                if (code3 < 32768)
                    mas[i] = (char)code3;
                else
                    mas[i] = str[i];
                code2.Clear();
            }
            string str2 = "";
            for (int i = 0; i < str.Length; i++)
                str2 = str2 + mas[i];
            return str2;
        }

        /// <summary>
        /// Уничтожает процесс
        /// </summary>
        /// <param name="name"></param>
        public void CProcces(string ProcessName)
        {
            Process[] p = Process.GetProcessesByName(ProcessName);
            foreach (Process p1 in p)
            {
                p1.Kill();
            }
        }

        /// <summary>
        /// Создаёт ярлык с указанными параметрами
        /// </summary>
        /// <param name="PathToShortCut">Путь к каталогу для сохранения ярлыка</param>
        /// <param name="Name">Имя ярлыка</param>
        /// <param name="PathToApp">Полный путь к файлу</param>
        /// <param name="Description">Описание к ярлыку</param>
        public void CreateShortCut(string PathToShortCut, string Name, string PathToApp, string Description = "")
        {
            //Ссылка на сборку: Windows Script Host Object Model на вкладке .COM

            //путь к ярлыку
            WshShell shell = new WshShell();

            string shortcutPath = PathToShortCut + @"\" + Name + ".lnk";

            //создаем объект ярлыка
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

            //задаем свойства для ярлыка
            //описание ярлыка в всплывающей подсказке
            shortcut.Description = Description;
            //путь к самой программе
            shortcut.TargetPath = PathToApp;

            //Создаем ярлык
            shortcut.Save();
        }
    }
}
