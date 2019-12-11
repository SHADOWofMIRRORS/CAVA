using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CAVA
{
    /// <summary>
    /// CAVAAdapter.Название_Таблицы(ref Название_TableAdapter,ref Название_DataSet, Команда Fill или Update);
    /// </summary>
    class CAVATableAdapter
    {
        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void Acc(ref CAVADataSetTableAdapters.AccTableAdapter TableAdatpter, ref CAVADataSet DataSet, string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.Acc);
            else
            {
                try
                {
                    if (Command == "update")
                        TableAdatpter.Update(DataSet.Acc);
                }
                catch (Exception)
                {
                    Acc(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void Computers(ref CAVADataSetTableAdapters.ComputersTableAdapter TableAdatpter, ref CAVADataSet DataSet, string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.Computers);
            else
            {
                try
                {
                    if (Command == "update")
                        TableAdatpter.Update(DataSet.Computers);
                }
                catch (Exception)
                {
                    Computers(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void AccordanceL(ref CAVADataSetTableAdapters.AccordanceLTableAdapter TableAdatpter, ref CAVADataSet DataSet , string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.AccordanceL);
            else
            {
                try
                {
                    if (Command == "update")
                        TableAdatpter.Update(DataSet.AccordanceL);
                }
                catch (Exception)
                {
                    AccordanceL(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void AccordanceR(ref CAVADataSetTableAdapters.AccordanceRTableAdapter TableAdatpter, ref CAVADataSet DataSet, string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.AccordanceR);
            else
            {
                try
                {
                    if (Command == "update")
                        TableAdatpter.Update(DataSet.AccordanceR);
                }
                catch (Exception)
                {
                    AccordanceR(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void Answer(ref CAVADataSetTableAdapters.AnswerTableAdapter TableAdatpter, ref CAVADataSet DataSet, string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.Answer);
            else
            {
                try
                {
                    if (Command == "update")
                        TableAdatpter.Update(DataSet.Answer);
                }
                catch (Exception)
                {
                    Answer(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void Clas(ref CAVADataSetTableAdapters.ClasTableAdapter TableAdatpter, ref CAVADataSet DataSet, string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.Clas);
            else
            {
                try
                {

                    if (Command == "update")
                        TableAdatpter.Update(DataSet.Clas);
                }
                catch (Exception)
                {
                    Clas(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void Pupil(ref CAVADataSetTableAdapters.PupilTableAdapter TableAdatpter, ref CAVADataSet DataSet, string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.Pupil);
            else
            {
                try
                {

                    if (Command == "update")
                        TableAdatpter.Update(DataSet.Pupil);
                }
                catch (Exception)
                {
                    Pupil(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void Questions(ref CAVADataSetTableAdapters.QuestionsTableAdapter TableAdatpter, ref CAVADataSet DataSet, string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.Questions);
            else
            {
                try
                {

                    if (Command == "update")
                        TableAdatpter.Update(DataSet.Questions);
                }
                catch (Exception)
                {
                    Questions(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void Sub(ref CAVADataSetTableAdapters.SubTableAdapter TableAdatpter, ref CAVADataSet DataSet, string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.Sub);
            else
            {
                try
                {

                    if (Command == "update")
                        TableAdatpter.Update(DataSet.Sub);
                }
                catch (Exception)
                {
                    Sub(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void Teacher(ref CAVADataSetTableAdapters.TeacherTableAdapter TableAdatpter, ref CAVADataSet DataSet, string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.Teacher);
            else
            {
                try
                {

                    if (Command == "update")
                        TableAdatpter.Update(DataSet.Teacher);
                }
                catch (Exception)
                {
                    Teacher(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void Test(ref CAVADataSetTableAdapters.TestTableAdapter TableAdatpter, ref CAVADataSet DataSet, string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.Test);
            else
            {
                try
                {

                    if (Command == "update")
                        TableAdatpter.Update(DataSet.Test);
                }
                catch (Exception)
                {
                    Test(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void Update(ref CAVADataSetTableAdapters.UpdateTableAdapter TableAdatpter, ref CAVADataSet DataSet, string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.Update);
            else
            {
                try
                {

                    if (Command == "update")
                        TableAdatpter.Update(DataSet.Update);
                }
                catch (Exception)
                {
                    Update(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

        /// <summary>
        /// Выполняет указанный запрос ссылаясь на нужный TableAdapter
        /// </summary>
        /// <param name="TableAdatpter">Имя</param>
        /// <param name="DataSet">dataSet</param>
        /// <param name="Command">Fill или Update</param>
        public static void ResultTable(ref CAVADataSetTableAdapters.TableResultSettingsTableAdapter TableAdatpter, ref CAVADataSet DataSet, string Command)
        {
            Command = Command.ToLower();
            if (Command == "fill")
                TableAdatpter.Fill(DataSet.TableResultSettings);
            else
            {
                try
                {

                    if (Command == "update")
                        TableAdatpter.Update(DataSet.TableResultSettings);
                }
                catch (Exception)
                {
                    ResultTable(ref TableAdatpter, ref DataSet, Command);
                }
            }
        }

    }
}
