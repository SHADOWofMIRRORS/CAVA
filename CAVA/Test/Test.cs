using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataGridViewRadioButtonElements;
using System.IO;
using System.Reflection;
using System.Net;

namespace CAVA.Test
{
    public partial class Test : MetroForm
    {
        public Test()
        {
            InitializeComponent();
        }

        public int t = 0;
        public int s = 0;
        public int c = 0;
        public int p = 0;
        public int a = 0;
        public int ComputerId = -1;
        public int TestRow = 0;
        double marc = 0;
        bool TestCreaTOR;
        int i1 = 0;
        int time;
        string Pas = "";
        bool X = false;
        int ShowQuestionsCount;

        bool SoftCheck = false;
        bool TypeOfCheck = true;
        bool Brawl = false;
        bool TimerSaving = false;

        bool FastMode = false;

        private void timer_Tick(object sender, EventArgs e)
        {
            computersTableAdapter.Fill(cAVADataSet.Computers);
            if (Convert.ToInt32(G(computersTime)) != time && Convert.ToInt32(G(computersTime)) > 0)
            {
                if (Convert.ToInt32(G(computersTime)) <= PrBar.Maximum)
                    time = Convert.ToInt32(G(computersTime));
                else
                {
                    if (Convert.ToInt32(G(computersTime)) < 2147483647)
                    {
                        PrBar.Maximum = Convert.ToInt32(G(computersTime));
                        time = Convert.ToInt32(G(computersTime));
                    }
                }
            }
            if (Convert.ToBoolean(G(computersStop)))
            {
                Ready();
            }
            if (time != -1)
            {
                time = time - 1;
                Time.Text = time.ToString();
                PrBar.Value = time;
                if (PrBar.Value * 100 / PrBar.Maximum > 50)
                {
                    PrBar.Style = MetroFramework.MetroColorStyle.Green;
                }
                if (PrBar.Value * 100 / PrBar.Maximum <= 50)
                {
                    PrBar.Style = MetroFramework.MetroColorStyle.Orange;
                }
                if (PrBar.Value * 100 / PrBar.Maximum <= 25)
                {
                    PrBar.Style = MetroFramework.MetroColorStyle.Red;
                }
                computersTableAdapter.Fill(cAVADataSet.Computers);
                R(computersTime, time);
                computersTableAdapter.Update(cAVADataSet.Computers);
                if (time == 0)
                {
                    Ready();
                }
            }
        }

        void Ready()
        {
            computersTableAdapter.Fill(cAVADataSet.Computers);
            time = -1;
            R(computersStop, false);
            R(computersStart, false);
            R(computersTime, 0);
            computersTableAdapter.Update(cAVADataSet.Computers);
            timer.Stop();
            TimerSaving = true;
            Saving();
        }

        void Saving()
        {
            if (CheckEmptyAnswers() == true)
            {
                /*
                SoftCheck = false — жёсткая проверка Для начисления баллов, нужно дать абсолютно верный ответ; true = Баллы начисляются даже при частично верном ответе
                TypeOfCheck = true — от максимального балла. false = Балл за каждый вопрос.

                Для получения балла за выбранный вопрос questionsDataGridView.Rows[i].Cells[5].Value.ToString();


                  testDataGridView.CurrentRow.Index номер строки текущего выбранного теста
                  questionsDataGridView.CurrentRow.Index  номер строки текущего выбранного вопроса
                  answerDataGridView.CurrentRow.Index номер строки текущего выбранного ответа


                testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[4].Value.ToString() отвечает за максимальный балл в тесте
                 */
                label10.Text = ""; //Обязательно
                double overlap = 0;
                double co = 0; ////Если в данном вопросе не было допущено ни одной ошибки, то co++
                double out_ = 0; //Переменная, которая отвечает за кол-во неверных ответов
                double cr = 0; // Количество выбранных верных ответов
                bool check = true; //В случае хотя бы одного ответа при жёсткой проверке, который несоотвествует заданным - check = false
                bool check_overlap = false;
                //Переменная mark отвечает за итоговую оценку.

                // CountOfTrueQuestions(int) Колчисетво верных ответов в выбранном вопросе
                if (Brawl == false)
                {
                    if (SoftCheck == false && TypeOfCheck == true) // Жёсткая проверка и максимальный балл.
                    {
                        for (int i = 0; i < questionsDataGridView.RowCount; i++) //Перебор всех вопросов
                        {
                            check = true;
                            check_overlap = false;
                            cr = 0;
                            questionsDataGridView.CurrentCell = questionsDataGridView[0, i]; // Выбор вопроса
                                                                                             //answerDataGridView.RowCount отвечает за общее количество ответов в данном вопросу
                            if (questionsDataGridView.Rows[questionsDataGridView.CurrentRow.Index].Cells[questionsQuestionType.Name].Value.ToString() == "Accordance")
                            {
                                for (int j = 0; j < accordanceLDataGridView.RowCount; j++)
                                {
                                    try
                                    {
                                        if (accordanceLDataGridView.Rows[Convert.ToInt32(accordanceRDataGridView.Rows[j].Cells[accordanceRUserAnswer.Name].Value.ToString()) - 1].Cells[accordanceLIndex.Name].Value.ToString() == accordanceRDataGridView.Rows[j].Cells[accordanceRIndex.Name].Value.ToString())
                                        {
                                            cr++;
                                            check_overlap = true;
                                        }
                                        else
                                        {
                                            check = false;
                                        }
                                    }
                                    catch
                                    {
                                        check = false;
                                    }
                                }
                                if (cr == accordanceLDataGridView.RowCount)
                                {
                                    co++;
                                }
                                else if (check_overlap == true)
                                {
                                    overlap++;
                                }
                            }
                            else
                            {
                                for (int j = 0; j < answerDataGridView.RowCount; j++) //Перебор всех ответов к данному вопросу
                                {
                                    //Обнаружение совпадений
                                    //answerDataGridView.Rows[j].Cells[2].Value.ToString() Является ли ответ верным
                                    if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() == V(j))
                                    {
                                        cr++;
                                        if (V(j) == "True")
                                        {
                                            check_overlap = true;
                                        }
                                    }
                                    else
                                    {
                                        check = false;
                                    }
                                }
                                if (cr == answerDataGridView.RowCount)//Если количество совпадений == количетсву строк-ответов
                                {
                                    co++;// Количество верных ответов
                                }
                                else if (check_overlap == true)
                                {
                                    overlap++;
                                }
                            }
                            ResultDataGridView.Rows.Add();
                            ResultDataGridView.Rows[i].Cells[Testnumb.Name].Value = i + 1;
                            ResultDataGridView.Rows[i].Cells[Max.Name].Value = Math.Round(Convert.ToDouble(
                            //Вот этот Cells[4] отвечает за максимальный балл
                            testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                            / (double)questionsDataGridView.RowCount, 2);
                            if (check == true)
                            {
                                //Расчёт итогового балла
                                if (ShowQuestionsCount > 0)
                                    marc += Convert.ToDouble(
                            //Вот этот Cells[4] отвечает за максимальный балл
                            testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                            / ShowQuestionsCount;
                                else
                                    marc += Convert.ToDouble(
                            //Вот этот Cells[4] отвечает за максимальный балл
                            testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                            / (double)questionsDataGridView.RowCount;
                                ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round(Convert.ToDouble(
                            //Вот этот Cells[4] отвечает за максимальный балл
                            testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                            / (double)questionsDataGridView.RowCount, 2);
                            }
                            else
                            {
                                ResultDataGridView.Rows[i].Cells[QMark.Name].Value = 0;
                            }
                        }
                    }


                    else if (SoftCheck == true && TypeOfCheck == true) // Мягкая проверка и максимальный балл.
                    {
                        label10.Visible = true;
                        if (Properties.Settings.Default.LANG == "BE") //Локализация программы.
                        {
                            label10.Text = "Вы атрымалі балы пры\nчасткова правільных адказах.\n";
                        }
                        else if (Properties.Settings.Default.LANG == "RU")
                        {
                            label10.Text = "Вы получили баллы при\nчастично верных ответах.\n";
                        }
                        for (int i = 0; i < questionsDataGridView.RowCount; i++) //Перебор всех вопросов
                        {
                            ResultDataGridView.Rows.Add();
                            ResultDataGridView.Rows[i].Cells[Testnumb.Name].Value = i + 1;
                            ResultDataGridView.Rows[i].Cells[Max.Name].Value = Math.Round(Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                                  / questionsDataGridView.RowCount, 2);
                            out_ = 0;
                            cr = 0;
                            questionsDataGridView.CurrentCell = questionsDataGridView[0, i]; // Выбор вопроса
                            check_overlap = false;
                            //answerDataGridView.RowCount отвечает за общее количество ответов в данном вопросу
                            if (questionsDataGridView.Rows[questionsDataGridView.CurrentRow.Index].Cells[questionsQuestionType.Name].Value.ToString() == "Accordance")
                            {
                                for (int j = 0; j < accordanceLDataGridView.RowCount; j++)
                                {
                                    try
                                    {
                                        if (accordanceLDataGridView.Rows[Convert.ToInt32(accordanceRDataGridView.Rows[j].Cells[accordanceRUserAnswer.Name].Value.ToString()) - 1].Cells[accordanceLIndex.Name].Value.ToString() == accordanceRDataGridView.Rows[j].Cells[accordanceRIndex.Name].Value.ToString())
                                        {
                                            cr++;
                                            check_overlap = true;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                if (ShowQuestionsCount > 0)
                                    marc +=
                                                   cr / accordanceLDataGridView.RowCount
                                                   * Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                                   / ShowQuestionsCount;
                                else
                                    marc +=
                                                   cr / accordanceLDataGridView.RowCount
                                                   * Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                                  / questionsDataGridView.RowCount;
                                ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round(cr / accordanceLDataGridView.RowCount
                                                   * Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                                  / questionsDataGridView.RowCount, 2);
                                if (cr == accordanceLDataGridView.RowCount)
                                {
                                    co++;
                                }
                                else if (check_overlap == true)
                                {
                                    overlap++;
                                }
                            }
                            else
                            {
                                for (int j = 0; j < answerDataGridView.RowCount; j++) //Перебор всех ответов к данному вопросу
                                {

                                    //Обнаружение совпадений
                                    //answerDataGridView.Rows[j].Cells[2].Value.ToString() Является ли ответ верным
                                    if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() == "True") //Если ответ был выбран
                                    {
                                        if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() == V(j))
                                        {
                                            cr++; //Верный
                                            check_overlap = true;
                                        }
                                    }
                                    else if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() != V(j))
                                    {
                                        out_++; //Неверныый
                                    }
                                }
                                if (CountOfTrueQuestions(i) == 0) //Если все ответы заданы, как неверные
                                {
                                    if (out_ == 0)
                                    {
                                        if (ShowQuestionsCount > 0)
                                            marc += Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString()) / ShowQuestionsCount; //Добавляем максимальный балл за каждый вопрос, если не один из вариантов ответов выбран не был
                                        else
                                            marc += Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString()) / questionsDataGridView.RowCount;
                                        ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round(Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString()) / questionsDataGridView.RowCount, 2);
                                        co++;
                                    }
                                }
                                else
                                {
                                    if (cr + out_ > 0)
                                    {   //Если был выбран хотя бы один ответ из предложенных
                                        if (ShowQuestionsCount > 0)
                                            marc +=
                                            cr / CountOfTrueQuestions(i) * cr / (cr + out_)
                                            * Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                            / ShowQuestionsCount;
                                        else
                                            marc +=
                                            cr / CountOfTrueQuestions(i) * cr / (cr + out_)
                                            * Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                           / questionsDataGridView.RowCount;
                                        ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round(cr / CountOfTrueQuestions(i) * cr / (cr + out_)
                                            * Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                           / questionsDataGridView.RowCount, 2);
                                        if (((cr / CountOfTrueQuestions(i)) * (cr / (cr + out_))) == 1) //Если в данном вопросе не было допущено ни одной ошибки
                                            co++;
                                        else if (check_overlap == true)
                                            overlap++;
                                    }
                                    else
                                        ResultDataGridView.Rows[i].Cells[QMark.Name].Value = 0;
                                }
                            }
                        }
                    }


                    else if (SoftCheck == true && TypeOfCheck == false) // Мягкая проверка и отдельный балл.
                    {
                        pResultMark.Visible = true;

                        if (Properties.Settings.Default.LANG == "BE") //Локализация программы.
                        {
                            label10.Text = "Вы атрымалі балы пры\nчасткова правільных адказах.\n";
                        }
                        else if (Properties.Settings.Default.LANG == "RU")
                        {
                            label10.Text = "Вы получили баллы при\nчастично верных ответах.\n";
                        }
                        for (int i = 0; i < questionsDataGridView.RowCount; i++) //Перебор всех вопросов
                        {
                            ResultDataGridView.Rows.Add();
                            ResultDataGridView.Rows[i].Cells[Testnumb.Name].Value = i + 1;
                            ResultDataGridView.Rows[i].Cells[Max.Name].Value = Math.Round(Convert.ToDouble(questionsDataGridView.Rows[i].Cells[questionsMark.Name].Value.ToString()), 2);
                            check_overlap = false;
                            out_ = 0;
                            cr = 0;
                            questionsDataGridView.CurrentCell = questionsDataGridView[0, i]; // Выбор вопроса
                                                                                             //answerDataGridView.RowCount отвечает за общее количество ответов в данном вопросу
                            if (questionsDataGridView.Rows[questionsDataGridView.CurrentRow.Index].Cells[questionsQuestionType.Name].Value.ToString() == "Accordance")
                            {

                                for (int j = 0; j < accordanceLDataGridView.RowCount; j++)
                                {
                                    try
                                    {
                                        if (accordanceLDataGridView.Rows[Convert.ToInt32(accordanceRDataGridView.Rows[j].Cells[accordanceRUserAnswer.Name].Value.ToString()) - 1].Cells[accordanceLIndex.Name].Value.ToString() == accordanceRDataGridView.Rows[j].Cells[accordanceRIndex.Name].Value.ToString())
                                        {
                                            cr++;
                                            check_overlap = true;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                marc += (cr / accordanceLDataGridView.RowCount) * Convert.ToDouble(questionsDataGridView.Rows[i].Cells[questionsMark.Name].Value.ToString());
                                ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round((cr / accordanceLDataGridView.RowCount) * Convert.ToDouble(questionsDataGridView.Rows[i].Cells[questionsMark.Name].Value.ToString()), 2);
                                if (cr == accordanceLDataGridView.RowCount)
                                {
                                    co++;
                                }
                                else if (check_overlap == true)
                                {
                                    overlap++;
                                }
                            }
                            else
                            {
                                for (int j = 0; j < answerDataGridView.RowCount; j++) //Перебор всех ответов к данному вопросу
                                {
                                    //Обнаружение совпадений
                                    //answerDataGridView.Rows[j].Cells[2].Value.ToString() Является ли ответ верным
                                    if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() == "True") //Если ответ был выбран
                                    {

                                        if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() == V(j))
                                        {
                                            cr++; //Верный
                                            check_overlap = true;
                                        }
                                    }
                                    else if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() != V(j))
                                        out_++; //Неверныый
                                }
                                if (CountOfTrueQuestions(i) == 0) //Если все ответы заданы, как неверные
                                {
                                    if (out_ == 0)
                                    {
                                        marc += Convert.ToDouble(questionsDataGridView.Rows[i].Cells[questionsMark.Name].Value.ToString()); //Добавляем максимальный балл, заданный для данного вопроса, за каждый вопрос, если не один из вариантов ответов выбран не был
                                        ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round(Convert.ToDouble(questionsDataGridView.Rows[i].Cells[questionsMark.Name].Value.ToString()), 2);
                                        co++;
                                    }
                                }
                                else
                                {
                                    if (cr + out_ > 0) //Если был выбран хотя бы один ответ из предложенных
                                    {
                                        marc += (cr / CountOfTrueQuestions(i)) * (cr / (cr + out_)) * Convert.ToDouble(questionsDataGridView.Rows[i].Cells[questionsMark.Name].Value.ToString());
                                        ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round((cr / CountOfTrueQuestions(i)) * (cr / (cr + out_)) * Convert.ToDouble(questionsDataGridView.Rows[i].Cells[questionsMark.Name].Value.ToString()), 2);
                                        if (((cr / CountOfTrueQuestions(i)) * (cr / (cr + out_))) == 1) //Если в данном вопросе не было допущено ни одной ошибки
                                            co++;
                                        else if (check_overlap == true)
                                            overlap++;
                                    }
                                    else
                                        ResultDataGridView.Rows[i].Cells[QMark.Name].Value = 0;
                                }
                            }
                        }
                    }


                    else if (SoftCheck == false && TypeOfCheck == false) // Жёсткая проверка и отдельный балл.
                    {
                        pResultMark.Visible = true;
                        for (int i = 0; i < questionsDataGridView.RowCount; i++) //Перебор всех вопросов
                        {
                            check_overlap = false;
                            check = true;
                            cr = 0;
                            questionsDataGridView.CurrentCell = questionsDataGridView[0, i]; // Выбор вопроса

                            //answerDataGridView.RowCount отвечает за общее количество ответов в данном вопросу
                            if (questionsDataGridView.Rows[questionsDataGridView.CurrentRow.Index].Cells[questionsQuestionType.Name].Value.ToString() == "Accordance")
                            {
                                for (int j = 0; j < accordanceLDataGridView.RowCount; j++)
                                {
                                    try
                                    {
                                        if (accordanceLDataGridView.Rows[Convert.ToInt32(accordanceRDataGridView.Rows[j].Cells[accordanceRUserAnswer.Name].Value.ToString()) - 1].Cells[accordanceLIndex.Name].Value.ToString() == accordanceRDataGridView.Rows[j].Cells[accordanceRIndex.Name].Value.ToString())
                                        {
                                            cr++;
                                            check_overlap = true;
                                        }
                                        else
                                        {
                                            check = false;
                                        }
                                    }
                                    catch
                                    {
                                        check = false;
                                    }
                                }
                                if (check == true) //Если в данном вопросе нет ни одной ошибки
                                {
                                    marc += Convert.ToDouble(questionsDataGridView.Rows[i].Cells[questionsMark.Name].Value.ToString()); //Добавляем максимальный балл, заданный для данного вопроса, за каждый вопрос, ответы на который были абсолютно верными
                                    co++;
                                }
                                else if (check_overlap == true)
                                {
                                    overlap++;
                                }
                            }
                            else
                            {
                                for (int j = 0; j < answerDataGridView.RowCount; j++) //Перебор всех ответов к данному вопросу
                                {

                                    //Обнаружение совпадений
                                    //answerDataGridView.Rows[j].Cells[2].Value.ToString() Является ли ответ верным
                                    if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() == V(j))
                                    {
                                        cr++;
                                        if (V(j) == "True")
                                        {
                                            check_overlap = true;
                                        }
                                    }
                                    else
                                    {
                                        check = false;
                                    }
                                }
                                if (cr == answerDataGridView.RowCount)//Если количество совпадений == количетсву строк-ответов
                                {
                                    marc += Convert.ToDouble(questionsDataGridView.Rows[i].Cells[questionsMark.Name].Value.ToString()); //Добавляем максимальный балл, заданный для данного вопроса, за каждый вопрос, ответы на который были абсолютно верными
                                    co++;// Количество верных ответов
                                }
                                else if (check_overlap == true)
                                {
                                    overlap++;
                                }
                            }
                            ResultDataGridView.Rows.Add();
                            ResultDataGridView.Rows[i].Cells[Testnumb.Name].Value = i + 1;
                            ResultDataGridView.Rows[i].Cells[Max.Name].Value = Math.Round(Convert.ToDouble(questionsDataGridView.Rows[i].Cells[questionsMark.Name].Value.ToString()), 2);
                            if (check == true)
                            {
                                ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round(Convert.ToDouble(questionsDataGridView.Rows[i].Cells[questionsMark.Name].Value.ToString()), 2);
                            }
                            else
                            {
                                ResultDataGridView.Rows[i].Cells[QMark.Name].Value = 0;
                            }
                        }
                    }
                }
                else
                {
                    if (SoftCheck == false && TypeOfCheck == true) // Жёсткая проверка и максимальный балл.
                    {
                        for (int i = 0; i < tableresultnumber.Count; i++) //Перебор всех вопросов
                        {
                            check = true;
                            check_overlap = false;
                            cr = 0;
                            questionsDataGridView.CurrentCell = questionsDataGridView[0, tableresultnumber[i]]; // Выбор вопроса
                                                                                                                //answerDataGridView.RowCount отвечает за общее количество ответов в данном вопросу
                            if (questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsQuestionType.Name].Value.ToString() == "Accordance")
                            {
                                for (int j = 0; j < accordanceLDataGridView.RowCount; j++)
                                {
                                    try
                                    {
                                        if (accordanceLDataGridView.Rows[Convert.ToInt32(accordanceRDataGridView.Rows[j].Cells[accordanceRUserAnswer.Name].Value.ToString()) - 1].Cells[accordanceLIndex.Name].Value.ToString() == accordanceRDataGridView.Rows[j].Cells[accordanceRIndex.Name].Value.ToString())
                                        {
                                            cr++;
                                            check_overlap = true;
                                        }
                                        else
                                        {
                                            check = false;
                                        }
                                    }
                                    catch
                                    {
                                        check = false;
                                    }
                                }
                                if (cr == accordanceLDataGridView.RowCount)
                                {
                                    co++;
                                }
                                else if (check_overlap == true)
                                {
                                    overlap++;
                                }
                            }
                            else
                            {
                                for (int j = 0; j < answerDataGridView.RowCount; j++) //Перебор всех ответов к данному вопросу
                                {
                                    //Обнаружение совпадений
                                    //answerDataGridView.Rows[j].Cells[2].Value.ToString() Является ли ответ верным
                                    if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() == V(j))
                                    {
                                        cr++;
                                        if (V(j) == "True")
                                        {
                                            check_overlap = true;
                                        }
                                    }
                                    else
                                    {
                                        check = false;
                                    }
                                }
                                if (cr == answerDataGridView.RowCount)//Если количество совпадений == количетсву строк-ответов
                                {
                                    co++;// Количество верных ответов
                                }
                                else if (check_overlap == true)
                                {
                                    overlap++;
                                }
                            }
                            ResultDataGridView.Rows.Add();
                            ResultDataGridView.Rows[i].Cells[Testnumb.Name].Value = i + 1;
                            ResultDataGridView.Rows[i].Cells[Max.Name].Value = Math.Round(Convert.ToDouble(
                            //Вот этот Cells[4] отвечает за максимальный балл
                            testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                            / (double)questionsDataGridView.RowCount, 2);
                            if (check == true)
                            {
                                //Расчёт итогового балла
                                if (ShowQuestionsCount > 0)
                                    marc += Convert.ToDouble(
                            //Вот этот Cells[4] отвечает за максимальный балл
                            testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                            / ShowQuestionsCount;
                                else
                                    marc += Convert.ToDouble(
                            //Вот этот Cells[4] отвечает за максимальный балл
                            testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                            / (double)questionsDataGridView.RowCount;
                                ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round(Convert.ToDouble(
                            //Вот этот Cells[4] отвечает за максимальный балл
                            testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                            / (double)questionsDataGridView.RowCount, 2);
                            }
                            else
                            {
                                ResultDataGridView.Rows[i].Cells[QMark.Name].Value = 0;
                            }
                        }
                    }


                    else if (SoftCheck == true && TypeOfCheck == true) // Мягкая проверка и максимальный балл.
                    {
                        label10.Visible = true;
                        if (Properties.Settings.Default.LANG == "BE") //Локализация программы.
                        {
                            label10.Text = "Вы атрымалі балы пры\nчасткова правільных адказах.\n";
                        }
                        else if (Properties.Settings.Default.LANG == "RU")
                        {
                            label10.Text = "Вы получили баллы при\nчастично верных ответах.\n";
                        }
                        for (int i = 0; i < tableresultnumber.Count; i++) //Перебор всех вопросов
                        {
                            ResultDataGridView.Rows.Add();
                            ResultDataGridView.Rows[i].Cells[Testnumb.Name].Value = i + 1;
                            ResultDataGridView.Rows[i].Cells[Max.Name].Value = Math.Round(Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                                  / questionsDataGridView.RowCount, 2);
                            out_ = 0;
                            cr = 0;
                            questionsDataGridView.CurrentCell = questionsDataGridView[0, tableresultnumber[i]]; // Выбор вопроса
                            check_overlap = false;
                            //answerDataGridView.RowCount отвечает за общее количество ответов в данном вопросу
                            if (questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsQuestionType.Name].Value.ToString() == "Accordance")
                            {
                                for (int j = 0; j < accordanceLDataGridView.RowCount; j++)
                                {
                                    try
                                    {
                                        if (accordanceLDataGridView.Rows[Convert.ToInt32(accordanceRDataGridView.Rows[j].Cells[accordanceRUserAnswer.Name].Value.ToString()) - 1].Cells[accordanceLIndex.Name].Value.ToString() == accordanceRDataGridView.Rows[j].Cells[accordanceRIndex.Name].Value.ToString())
                                        {
                                            cr++;
                                            check_overlap = true;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                if (ShowQuestionsCount > 0)
                                    marc +=
                                                   cr / accordanceLDataGridView.RowCount
                                                   * Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                                   / ShowQuestionsCount;
                                else
                                    marc +=
                                                   cr / accordanceLDataGridView.RowCount
                                                   * Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                                  / questionsDataGridView.RowCount;
                                ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round(cr / accordanceLDataGridView.RowCount
                                                   * Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                                  / questionsDataGridView.RowCount, 2);
                                if (cr == accordanceLDataGridView.RowCount)
                                {
                                    co++;
                                }
                                else if (check_overlap == true)
                                {
                                    overlap++;
                                }
                            }
                            else
                            {
                                for (int j = 0; j < answerDataGridView.RowCount; j++) //Перебор всех ответов к данному вопросу
                                {

                                    //Обнаружение совпадений
                                    //answerDataGridView.Rows[j].Cells[2].Value.ToString() Является ли ответ верным
                                    if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() == "True") //Если ответ был выбран
                                    {
                                        if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() == V(j))
                                        {
                                            cr++; //Верный
                                            check_overlap = true;
                                        }
                                    }
                                    else if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() != V(j))
                                    {
                                        out_++; //Неверныый
                                    }
                                }
                                if (CountOfTrueQuestions(tableresultnumber[i]) == 0) //Если все ответы заданы, как неверные
                                {
                                    if (out_ == 0)
                                    {
                                        if (ShowQuestionsCount > 0)
                                            marc += Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString()) / ShowQuestionsCount; //Добавляем максимальный балл за каждый вопрос, если не один из вариантов ответов выбран не был
                                        else
                                            marc += Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString()) / questionsDataGridView.RowCount;
                                        ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round(Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString()) / questionsDataGridView.RowCount, 2);
                                        co++;
                                    }
                                }
                                else
                                {
                                    if (cr + out_ > 0)
                                    {   //Если был выбран хотя бы один ответ из предложенных
                                        if (ShowQuestionsCount > 0)
                                            marc +=
                                            cr / CountOfTrueQuestions(tableresultnumber[i]) * cr / (cr + out_)
                                            * Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                            / ShowQuestionsCount;
                                        else
                                            marc +=
                                            cr / CountOfTrueQuestions(tableresultnumber[i]) * cr / (cr + out_)
                                            * Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                           / questionsDataGridView.RowCount;
                                        ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round(cr / CountOfTrueQuestions(tableresultnumber[i]) * cr / (cr + out_)
                                            * Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString())
                                           / questionsDataGridView.RowCount, 2);
                                        if (((cr / CountOfTrueQuestions(tableresultnumber[i])) * (cr / (cr + out_))) == 1) //Если в данном вопросе не было допущено ни одной ошибки
                                            co++;
                                        else if (check_overlap == true)
                                            overlap++;
                                    }
                                    else
                                        ResultDataGridView.Rows[i].Cells[QMark.Name].Value = 0;
                                }
                            }
                        }
                    }


                    else if (SoftCheck == true && TypeOfCheck == false) // Мягкая проверка и отдельный балл.
                    {
                        pResultMark.Visible = true;

                        if (Properties.Settings.Default.LANG == "BE") //Локализация программы.
                        {
                            label10.Text = "Вы атрымалі балы пры\nчасткова правільных адказах.\n";
                        }
                        else if (Properties.Settings.Default.LANG == "RU")
                        {
                            label10.Text = "Вы получили баллы при\nчастично верных ответах.\n";
                        }
                        for (int i = 0; i < tableresultnumber.Count; i++) //Перебор всех вопросов
                        {
                            ResultDataGridView.Rows.Add();
                            ResultDataGridView.Rows[i].Cells[Testnumb.Name].Value = i + 1;
                            ResultDataGridView.Rows[i].Cells[Max.Name].Value = Math.Round(Convert.ToDouble(questionsDataGridView.Rows[i].Cells[questionsMark.Name].Value.ToString()), 2);
                            check_overlap = false;
                            out_ = 0;
                            cr = 0;
                            questionsDataGridView.CurrentCell = questionsDataGridView[0, tableresultnumber[i]]; // Выбор вопроса
                                                                                                                //answerDataGridView.RowCount отвечает за общее количество ответов в данном вопросу
                            if (questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsQuestionType.Name].Value.ToString() == "Accordance")
                            {

                                for (int j = 0; j < accordanceLDataGridView.RowCount; j++)
                                {
                                    try
                                    {
                                        if (accordanceLDataGridView.Rows[Convert.ToInt32(accordanceRDataGridView.Rows[j].Cells[accordanceRUserAnswer.Name].Value.ToString()) - 1].Cells[accordanceLIndex.Name].Value.ToString() == accordanceRDataGridView.Rows[j].Cells[accordanceRIndex.Name].Value.ToString())
                                        {
                                            cr++;
                                            check_overlap = true;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                marc += (cr / accordanceLDataGridView.RowCount) * Convert.ToDouble(questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsMark.Name].Value.ToString());
                                ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round((cr / accordanceLDataGridView.RowCount) * Convert.ToDouble(questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsMark.Name].Value.ToString()), 2);
                                if (cr == accordanceLDataGridView.RowCount)
                                {
                                    co++;
                                }
                                else if (check_overlap == true)
                                {
                                    overlap++;
                                }
                            }
                            else
                            {
                                for (int j = 0; j < answerDataGridView.RowCount; j++) //Перебор всех ответов к данному вопросу
                                {
                                    //Обнаружение совпадений
                                    //answerDataGridView.Rows[j].Cells[2].Value.ToString() Является ли ответ верным
                                    if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() == "True") //Если ответ был выбран
                                    {

                                        if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() == V(j))
                                        {
                                            cr++; //Верный
                                            check_overlap = true;
                                        }
                                    }
                                    else if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() != V(j))
                                        out_++; //Неверныый
                                }
                                if (CountOfTrueQuestions(tableresultnumber[i]) == 0) //Если все ответы заданы, как неверные
                                {
                                    if (out_ == 0)
                                    {
                                        marc += Convert.ToDouble(questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsMark.Name].Value.ToString()); //Добавляем максимальный балл, заданный для данного вопроса, за каждый вопрос, если не один из вариантов ответов выбран не был
                                        ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round(Convert.ToDouble(questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsMark.Name].Value.ToString()), 2);
                                        co++;
                                    }
                                }
                                else
                                {
                                    if (cr + out_ > 0) //Если был выбран хотя бы один ответ из предложенных
                                    {
                                        marc += (cr / CountOfTrueQuestions(tableresultnumber[i])) * (cr / (cr + out_)) * Convert.ToDouble(questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsMark.Name].Value.ToString());
                                        ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round((cr / CountOfTrueQuestions(tableresultnumber[i])) * (cr / (cr + out_)) * Convert.ToDouble(questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsMark.Name].Value.ToString()), 2);
                                        if (((cr / CountOfTrueQuestions(tableresultnumber[i])) * (cr / (cr + out_))) == 1) //Если в данном вопросе не было допущено ни одной ошибки
                                            co++;
                                        else if (check_overlap == true)
                                            overlap++;
                                    }
                                    else
                                        ResultDataGridView.Rows[i].Cells[QMark.Name].Value = 0;
                                }
                            }
                        }
                    }


                    else if (SoftCheck == false && TypeOfCheck == false) // Жёсткая проверка и отдельный балл.
                    {
                        pResultMark.Visible = true;
                        for (int i = 0; i < tableresultnumber.Count; i++) //Перебор всех вопросов
                        {
                            check_overlap = false;
                            check = true;
                            cr = 0;
                            questionsDataGridView.CurrentCell = questionsDataGridView[0, tableresultnumber[i]]; // Выбор вопроса

                            //answerDataGridView.RowCount отвечает за общее количество ответов в данном вопросу
                            if (questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsQuestionType.Name].Value.ToString() == "Accordance")
                            {
                                for (int j = 0; j < accordanceLDataGridView.RowCount; j++)
                                {
                                    try
                                    {
                                        if (accordanceLDataGridView.Rows[Convert.ToInt32(accordanceRDataGridView.Rows[j].Cells[accordanceRUserAnswer.Name].Value.ToString()) - 1].Cells[accordanceLIndex.Name].Value.ToString() == accordanceRDataGridView.Rows[j].Cells[accordanceRIndex.Name].Value.ToString())
                                        {
                                            cr++;
                                            check_overlap = true;
                                        }
                                        else
                                        {
                                            check = false;
                                        }
                                    }
                                    catch
                                    {
                                        check = false;
                                    }
                                }
                                if (check == true) //Если в данном вопросе нет ни одной ошибки
                                {
                                    marc += Convert.ToDouble(questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsMark.Name].Value.ToString()); //Добавляем максимальный балл, заданный для данного вопроса, за каждый вопрос, ответы на который были абсолютно верными
                                    co++;
                                }
                                else if (check_overlap == true)
                                {
                                    overlap++;
                                }
                            }
                            else
                            {
                                for (int j = 0; j < answerDataGridView.RowCount; j++) //Перебор всех ответов к данному вопросу
                                {

                                    //Обнаружение совпадений
                                    //answerDataGridView.Rows[j].Cells[2].Value.ToString() Является ли ответ верным
                                    if (answerDataGridView.Rows[j].Cells[answerTrue.Name].Value.ToString() == V(j))
                                    {
                                        cr++;
                                        if (V(j) == "True")
                                        {
                                            check_overlap = true;
                                        }
                                    }
                                    else
                                    {
                                        check = false;
                                    }
                                }
                                if (cr == answerDataGridView.RowCount)//Если количество совпадений == количетсву строк-ответов
                                {
                                    marc += Convert.ToDouble(questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsMark.Name].Value.ToString()); //Добавляем максимальный балл, заданный для данного вопроса, за каждый вопрос, ответы на который были абсолютно верными
                                    co++;// Количество верных ответов
                                }
                                else if (check_overlap == true)
                                {
                                    overlap++;
                                }
                            }
                            ResultDataGridView.Rows.Add();
                            ResultDataGridView.Rows[i].Cells[Testnumb.Name].Value = i + 1;
                            ResultDataGridView.Rows[i].Cells[Max.Name].Value = Math.Round(Convert.ToDouble(questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsMark.Name].Value.ToString()), 2);
                            if (check == true)
                            {
                                ResultDataGridView.Rows[i].Cells[QMark.Name].Value = Math.Round(Convert.ToDouble(questionsDataGridView.Rows[tableresultnumber[i]].Cells[questionsMark.Name].Value.ToString()), 2);
                            }
                            else
                            {
                                ResultDataGridView.Rows[i].Cells[QMark.Name].Value = 0;
                            }
                        }
                    }
                }






                lMark.Text = "";

                marc = Math.Round(marc, 2);

                double Count = Math.Round(Convert.ToDouble(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString()) /
                            Convert.ToDouble(questionsDataGridView.RowCount), 2);

                if (Properties.Settings.Default.LANG == "BE") //Локализация программы.
                {
                    lMark.Text = "Меркаваная адзнака: " + marc;
                    if (TypeOfCheck == true ||
                        SoftCheck == false)
                    {
                        label10.Text += "Максiмум " + testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString();
                        label10.Text += ", за кожнае пытанне " + Count + " балл.";
                    }
                }
                else
                {
                    if (Properties.Settings.Default.LANG == "RU") //Локализация программы
                    {
                        lMark.Text = "Предполагаемая оценка: " + marc;
                        if (TypeOfCheck == true ||
                        SoftCheck == false)
                        {
                            label10.Text += "Максимум " + testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[testMaxMark.Name].Value.ToString();
                            label10.Text += ", за каждый вопрос " + Count + " балл.";
                        }
                    }
                }
                //Вывод результатов
                panelAccAnswer.Visible = false;
                answerDataGridView.Visible = false;
                lTrue.Text = co.ToString();
                lSoSo.Text = overlap.ToString();
                if (ShowQuestionsCount > 0)
                    lFalse.Text = (ShowQuestionsCount - (co + overlap)).ToString();
                else
                    lFalse.Text = (questionsDataGridView.RowCount - (co + overlap)).ToString();
                ImageBox.Visible = false;
                Question.Visible = false;
                Body.Visible = false;
                Result.Visible = true;
                btnYes.Visible = false;
                Time.Visible = false;
                timer.Stop();
                PrBar.Maximum = 100;
                PrBar.Value = 100;
                PrBar.Style = MetroFramework.MetroColorStyle.Green;
                SaveMark();
                computersTableAdapter.Fill(cAVADataSet.Computers);
                R(computersTime, 0);
                computersTableAdapter.Update(cAVADataSet.Computers);
                if (FastMode == true)
                {
                    testResultsTableAdapter.Fill(cAVADataSet.TestResults);
                    questionsResultsTableAdapter.Fill(cAVADataSet.QuestionsResults);
                    R(testResultsRecivedMark, marc, testResultsDataGridView.RowCount - 1);
                    testResultsTableAdapter.Update(cAVADataSet.TestResults);
                    questionsResultsTableAdapter.Update(cAVADataSet.QuestionsResults);
                }
                else
                {

                }
            }
        }

        void SaveMark()
        {
            if (FastMode == false)
            {
                try
                {
                    teacherDataGridView.CurrentCell = teacherDataGridView[0, t];
                    subDataGridView.CurrentCell = subDataGridView[0, s];
                    clasDataGridView.CurrentCell = clasDataGridView[0, c];
                    pupilDataGridView.CurrentCell = pupilDataGridView[0, p];
                    accDataGridView.CurrentCell = accDataGridView[0, a];
                    testDataGridView.CurrentCell = testDataGridView[0, TestRow];
                }
                catch (Exception ex)
                {

                }
                try
                {
                    R(accMark, marc, a);
                    teacherDataGridView.EndEdit();
                    subBindingSource.EndEdit();
                    clasBindingSource.EndEdit();
                    pupilBindingSource.EndEdit();
                    accBindingSource.EndEdit();

                    CAVATableAdapter.Acc(ref accTableAdapter, ref cAVADataSet, "Update");
                    CAVATableAdapter.Pupil(ref pupilTableAdapter, ref cAVADataSet, "Update");
                    CAVATableAdapter.Clas(ref clasTableAdapter, ref cAVADataSet, "Update");
                    CAVATableAdapter.Sub(ref subTableAdapter, ref cAVADataSet, "Update");
                    CAVATableAdapter.Teacher(ref teacherTableAdapter, ref cAVADataSet, "Update");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                computersTableAdapter.Fill(cAVADataSet.Computers);
                R(computersStop, false);
                R(computersStart, false);
                R(computersTime, 0);
                computersTableAdapter.Update(cAVADataSet.Computers);
            }
        }

        private void timerPas_Tick(object sender, EventArgs e)
        {
            btnPas.BackColor = Color.FromArgb(17, 17, 17);
            this.Style = MetroFramework.MetroColorStyle.Brown;
            Pas = null;
            timerPas.Stop();
        }

        private void btnPas_Click(object sender, EventArgs e)
        {
            if (X == true)
            {
                if (G(questionsQuestionType) == "Accordance")
                {
                    for (int i = 0; i < accordanceLDataGridView.RowCount; i++)
                        for (int j = 0; j < accordanceRDataGridView.RowCount; j++)
                            if (G(accordanceLIndex, i) == G(accordanceRIndex, j))
                                R(accordanceRUserAnswer, G(accordanceLUserAnswer, i), j);
                }
                else if (CountOfTrueQuestions(Q()) == 1)
                {
                    for (int i = 0; i < answerDataGridView.RowCount; i++)
                    {
                        if (G(answerTrue, i) == "True")
                            R(answerRadioButton, Properties.Resources.True, i);
                        else
                            R(answerRadioButton, Properties.Resources.False, i);
                    }
                }
                else
                {
                    //Код Checkbox //{
                    for (int i = 0; i < answerDataGridView.RowCount; i++)
                    {
                        R(answerUser, G(answerTrue, i), i);
                    }
                }
                //}
                dataGridViewlist.Rows[dataGridViewlist.CurrentRow.Index].DefaultCellStyle.BackColor = Color.FromArgb(0, 177, 89);
            }
        }

        private void PrBar_Click(object sender, EventArgs e)
        {
            if (X == true)
            {
                time += 10;
                PrBar.Maximum += 10;
            }
        }

        private void ImageBox_Click(object sender, EventArgs e)
        {
            ShowImage I = new ShowImage();
            I.Image = ImageBox.Image;
            I.Header = Question.Text;
            I.Show();
        }

        void LoadSettings()
        {
            try
            {
                CAVATableAdapter.Teacher(ref this.teacherTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Sub". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Sub(ref this.subTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Clas". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Clas(ref this.clasTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Pupil". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Pupil(ref this.pupilTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Acc". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Acc(ref this.accTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Test". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Test(ref this.testTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.TableResultSettings". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.ResultTable(ref this.tableResultSettingsTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Questions". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Questions(ref this.questionsTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Answer". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.Answer(ref this.answerTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.AccordanceL". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.AccordanceL(ref this.accordanceLTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.AccordanceR". При необходимости она может быть перемещена или удалена.
                CAVATableAdapter.AccordanceR(ref this.accordanceRTableAdapter, ref this.cAVADataSet, "Fill");
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.AnswerResults". При необходимости она может быть перемещена или удалена.
                this.answerResultsTableAdapter.Fill(this.cAVADataSet.AnswerResults);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.QuestionsResults". При необходимости она может быть перемещена или удалена.
                this.questionsResultsTableAdapter.Fill(this.cAVADataSet.QuestionsResults);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.TestResults". При необходимости она может быть перемещена или удалена.
                this.testResultsTableAdapter.Fill(this.cAVADataSet.TestResults);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "cAVADataSet.Computers". При необходимости она может быть перемещена или удалена.
                this.computersTableAdapter.FillId(this.cAVADataSet.Computers, ComputerId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить данные" + ex.Message, "CAVA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
        }

        private void Test_Load_1(object sender, EventArgs e)
        {
            LoadSettings();
            accordanceLDataGridView.Columns[0].Visible = false;
            accordanceRDataGridView.Columns[0].Visible = false;
            try
            {
                if (ComputerId != -1)
                {
                    FastMode = true;
                    for (int i = 0; i < testDataGridView.RowCount; i++)
                    {
                        if (G(testId, i) == TestRow.ToString())
                        {
                            testDataGridView.CurrentCell = testDataGridView[0, i];
                            TestRow = i;
                            break;
                        }
                    }
                }
                else
                {
                    teacherDataGridView.CurrentCell = teacherDataGridView[0, t];
                    subDataGridView.CurrentCell = subDataGridView[0, s];
                    clasDataGridView.CurrentCell = clasDataGridView[0, c];
                    pupilDataGridView.CurrentCell = pupilDataGridView[0, p];
                    accDataGridView.CurrentCell = accDataGridView[0, a];
                    testDataGridView.CurrentCell = testDataGridView[0, TestRow];
                    for (int i = 0; i < computersDataGridView.RowCount - 1; i++)
                    {
                        if (G(computersId, i) == Properties.Settings.Default.Id.ToString())
                        {
                            computersDataGridView.CurrentCell = computersDataGridView[0, i];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            if (G(testResultsTable) == "False" || G(testResultsTable) == "")
            {
                ResultDataGridView.Visible = false;
            }
            else
            {
                if (G(resultShowNumber) == "False")
                    ResultDataGridView.Columns[Testnumb.Name].Visible = false;
                if (G(resultShowMax) == "False")
                    ResultDataGridView.Columns[Max.Name].Visible = false;
                if (G(ResultShow) == "False")
                    ResultDataGridView.Columns[QMark.Name].Visible = false;
            }

            try
            {
                if (G(testChecking_Soft) == "True")
                {
                    SoftCheck = true;
                }
                if (G(testMaxMark) == "0")
                {
                    TypeOfCheck = false;
                }
                else
                {
                    TypeOfCheck = true;
                }
                if (G(testShowQuestionsCount) != "0")
                {
                    ShowQuestionsCount = Convert.ToInt32(G(testShowQuestionsCount));
                    int QuestionsCount = questionsDataGridView.RowCount;
                    int DeleteCount = QuestionsCount - ShowQuestionsCount;
                    for (int i = 0; i < DeleteCount; i++)
                    {
                        Random r = new Random((int)DateTime.Now.Ticks);
                        int RemoveId = r.Next(0, questionsDataGridView.RowCount);
                        questionsDataGridView.Rows.RemoveAt(RemoveId);
                    }
                }
                this.Text = G(testName);
                Question.Text = G(questionsQuestion);
                time = Convert.ToInt32(testDataGridView.Rows[testDataGridView.CurrentRow.Index].Cells[2].Value.ToString());
                label3.Text = Convert.ToInt32(Q() + 1) + "/" + questionsDataGridView.RowCount;
                PrBar.Maximum = time;
                timer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (Properties.Settings.Default.LANG == "BE")
            {
                label1.Text = "Кошт пытання";
                label4.Text = "Ваш вынік";
            }
            else if (Properties.Settings.Default.LANG == "EN")
            {
                label1.Text = "Question cost";
                label4.Text = "Your result";
            }

            try
            {
                ImageBox.Image = null;
                ImageBox.Invalidate();
                ImageBox.SizeMode = PictureBoxSizeMode.Zoom;
                ImageBox.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream((byte[])questionsDataGridView[questionsImg.Name, Q()].Value));
            }
            catch (Exception ex)
            {
                label11.Visible = true;
            }
            SetQuestionCost();
            if (G(testBrawl) == "")
                R(testBrawl, false);
            if (G(testBrawl) == "True")
            {
                Brawl = true;
                label3.Visible = false;
                labelBrawl.Visible = true;
                SelectNextRandomQ();
            }
            for (int i = 1; i <= questionsDataGridView.RowCount; i++)
            {
                dataGridViewlist.Rows.Add();
                dataGridViewlist.Rows[dataGridViewlist.RowCount - 1].Cells[0].Value = i;
            }

            if (G(testBackToQuestions) == "False" ||
                G(testBackToQuestions) == "")
            {
                dataGridViewlist.Visible = false;
            }

            int timerow = Q();
            for (int i = 0; i < questionsDataGridView.RowCount; i++)
            {
                questionsDataGridView.CurrentCell = questionsDataGridView[0, i];
                for (int j = 0; j < answerDataGridView.RowCount; j++)
                {
                    R(answerRadioButton, Properties.Resources.False, j);
                }
            }
            dataGridViewlist.Rows.Add();
            dataGridViewlist.Rows[dataGridViewlist.RowCount - 1].Cells[0].Value = "X";
            dataGridViewlist.Rows[dataGridViewlist.RowCount - 1].DefaultCellStyle.BackColor = Color.FromArgb(250, 50, 50);
            questionsDataGridView.CurrentCell = questionsDataGridView[0, timerow];
            SetQuestionType();

            if (FastMode == true)
            {
                string host = System.Net.Dns.GetHostName();
                // Получение ip-адреса.
                System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[0];
                // IP
                string IP = ip.ToString();
                byte[] Screen = new byte[1];
                // Сохранение результатов
                testResultsTableAdapter.Fill(cAVADataSet.TestResults);
                testResultsTableAdapter.Insert(G(computersName), DateTime.Now.ToString(), "", IP, Convert.ToInt32(G(testId)), Screen, "");
                testResultsTableAdapter.Update(cAVADataSet.TestResults);
                //for (int i = 0; i < questionsDataGridView.RowCount; i++)
                //{
                //    questionsResultsTableAdapter.Insert(G(questionsName, i), G(questionsQuestion, i), "0", 0, 0, 0, 0, Convert.ToInt32(G(testResultsId)), Convert.ToInt32(G(questionsId)), "");
                //}
            }
        }

        int CountOfTrueQuestions(int QuestionRowIndex)
        {
            int SelectedRow = Q();
            questionsDataGridView.CurrentCell = questionsDataGridView[0, QuestionRowIndex];
            int co = 0;
            for (int i = 0; i < answerDataGridView.RowCount; i++)
            {
                if (G(answerTrue, i) == "True")
                {
                    co = co + 1;
                }
            }
            questionsDataGridView.CurrentCell = questionsDataGridView[0, SelectedRow];
            return co;
        }
        int countofcallingsSelectNextQ = 0;
        void SelectNextQ() //Выбрать следующий вопрос
        {
            bool checkEND = false;
            int number;
            if (Brawl == false)
            {
                number = Q();
            }
            else
            {
                if (dataGridViewlist.Visible == false)
                {
                    number = countofcallingsSelectNextQ;
                }
                else
                {
                    number = dataGridViewlist.CurrentRow.Index;
                }
            }
            if (number < questionsDataGridView.RowCount - 1)
            {
                if (Brawl == false)
                {
                    questionsDataGridView.CurrentCell = questionsDataGridView[0, Convert.ToInt32(Q() + 1)];
                }
                else
                {
                    if (dataGridViewlist.Visible == false)
                    {
                        questionsDataGridView.CurrentCell = questionsDataGridView[0, thelistfromSelectNextRandomQ[countofcallingsSelectNextQ]];
                    }
                    else
                    {
                        questionsDataGridView.CurrentCell = questionsDataGridView[0, thelistfromSelectNextRandomQ[dataGridViewlist.CurrentRow.Index+1]];
                    }
                }
            }
            else
            {
                checkEND = true;
                if (dataGridViewlist.Visible == true)
                {
                    if (Brawl == false)
                    {
                        questionsDataGridView.CurrentCell = questionsDataGridView[0, 0];
                    }
                    else
                    {
                        questionsDataGridView.CurrentCell = questionsDataGridView[0, thelistfromSelectNextRandomQ[0]];
                    }
                    dataGridViewlist.CurrentCell = dataGridViewlist[0, 0];
                }
                else
                {
                    Saving();
                }
            }
            try
            {
                Question.Text = G(questionsQuestion);
                label3.Text = Convert.ToInt32(Q() + 1) + "/" + questionsDataGridView.RowCount;
            }
            catch (Exception ex)
            {

            }

            try
            {
                ImageBox.Image = null;
                ImageBox.Invalidate();
                ImageBox.SizeMode = PictureBoxSizeMode.Zoom;
                ImageBox.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream((byte[])questionsDataGridView[questionsImg.Name, Q()].Value));
                label11.Visible = false;
            }
            catch (Exception)
            {
                label11.Visible = true;
                ImageBox.Image = null;
                ImageBox.Invalidate();
            }
            if (Brawl == false)
            {
                number = Q();
            }
            else
            {
                if (dataGridViewlist.Visible == false)
                {
                    number = countofcallingsSelectNextQ + 1;
                }
                else
                {
                    number = dataGridViewlist.CurrentRow.Index + 1;
                }
            }
            if (checkEND == false)
            {
                dataGridViewlist.CurrentCell = dataGridViewlist[0, number];
            }
            else
            {
                dataGridViewlist.CurrentCell = dataGridViewlist[0, 0];
            }
            countofcallingsSelectNextQ++;
            SetQuestionType();
            SetQuestionCost();
        }
        bool checkthelistforSelectNextRandomQ = false;
        List<int> tableresultnumber = new List<int>();
        List<int> thelistforSelectNextRandomQ = new List<int>();
        List<int> thelistfromSelectNextRandomQ = new List<int>();
        void SelectNextRandomQ() //Выбрать следующий рандомный вопрос
        {
            //ShowQuestionsCount — Количество вопросов, которое нужно показать
            if (checkthelistforSelectNextRandomQ == false)
            {
                for (int i = 0; i < questionsDataGridView.RowCount; i++)
                {
                    thelistforSelectNextRandomQ.Add(i);
                }
                checkthelistforSelectNextRandomQ = true;
                for (int i = 0; i < questionsDataGridView.RowCount; i++)
                {
                    Random r = new Random((int)DateTime.Now.Ticks);
                    int rand = r.Next(0, thelistforSelectNextRandomQ.Count);
                    tableresultnumber.Add(thelistforSelectNextRandomQ[rand]);
                    thelistfromSelectNextRandomQ.Add(thelistforSelectNextRandomQ[rand]);
                    thelistforSelectNextRandomQ.RemoveAt(rand);
                }
            }
        }

        void SelectQ(int number_of_Row)
        {
            if (number_of_Row < questionsDataGridView.RowCount)
            {
                if (Brawl == false)
                {
                    questionsDataGridView.CurrentCell = questionsDataGridView[0, number_of_Row];
                }
                else
                {
                    questionsDataGridView.CurrentCell = questionsDataGridView[0, thelistfromSelectNextRandomQ[number_of_Row]];
                }
            }
            else
            {

            }
            try
            {
                Question.Text = G(questionsQuestion);
                label3.Text = Convert.ToInt32(Q() + 1) + "/" + questionsDataGridView.RowCount;
            }
            catch (Exception ex)
            {

            }

            try
            {
                ImageBox.Image = null;
                ImageBox.Invalidate();
                ImageBox.SizeMode = PictureBoxSizeMode.Zoom;
                ImageBox.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream((byte[])questionsDataGridView[questionsImg.Name, Q()].Value));
                label11.Visible = false;
            }
            catch (Exception)
            {
                label11.Visible = true;
                ImageBox.Image = null;
                ImageBox.Invalidate();
            }
            SetQuestionCost();
            SetQuestionType();
            dataGridViewlist.CurrentCell = dataGridViewlist[0, number_of_Row];
        }

        bool Equality(System.Drawing.Image Img1, System.Drawing.Image Img2)
        {
            Bitmap Bmp1 = new Bitmap(Img1);
            Bitmap Bmp2 = new Bitmap(Img2);
            if (Bmp1.Size == Bmp2.Size)
            {
                bool check = true;
                for (int i = 0; i < Bmp1.Width; i++)
                    for (int j = 0; j < Bmp1.Height; j++)
                        if (Bmp1.GetPixel(i, j) != Bmp2.GetPixel(i, j))
                            check = false;
                return check;
            }
            else
                return false;
        }

        /// <summary>
        /// Проверит значение ответа пользователя учитывая RadioButtons
        /// </summary>
        /// <param name="RowNumber"></param>
        /// <returns></returns>
        string V(int RowNumber)
        {
            if (CountOfTrueQuestions(Q()) > 1)
                return G(answerUser, RowNumber);
            else
            {
                System.Drawing.Image im = System.Drawing.Image.FromStream(new System.IO.MemoryStream((byte[])answerDataGridView[4, RowNumber].Value));
                return Equality(im, Properties.Resources.True).ToString();
            }
        }

        void SetQuestionCost()
        {
            double QestionCost = 0;

            if (TypeOfCheck == false) // отдельный балл
            {
                QestionCost = Math.Round(Convert.ToDouble(G(questionsMark)), 2);
            }
            else // максимальный
            {
                if (ShowQuestionsCount > 0)
                    QestionCost = Math.Round(Convert.ToDouble(G(testMaxMark, TestRow)) / Convert.ToDouble(ShowQuestionsCount), 2);
                else
                    QestionCost = Math.Round(Convert.ToDouble(G(testMaxMark, TestRow)) / Convert.ToDouble(questionsDataGridView.RowCount), 2);
            }

            if (Properties.Settings.Default.LANG == "BE")
            {
                label1.Text = "Кошт пытання " + QestionCost;
            }
            else if (Properties.Settings.Default.LANG == "EN")
            {
                label1.Text = "Cost of question " + QestionCost;
            }
            else
            {
                label1.Text = "Стоимоть вопроса " + QestionCost;
            }
        }

        void SetQuestionType()
        {
            if (CountOfTrueQuestions(Q()) == 1)
            {
                answerUser.Visible = false;
                answerRadioButton.Visible = true;
            }
            else
            {
                answerUser.Visible = true;
                answerRadioButton.Visible = false;
            }

            if (G(questionsQuestionType) == "Accordance")
            {
                answerDataGridView.Visible = false;
                panelAccAnswer.Visible = true;
                panelEtalonAnswer.Visible = false;
                AccordanceRandom();
                for (int i = 0; i < accordanceLDataGridView.RowCount; i++)
                {
                    R(accordanceLUserAnswer, i + 1, i);
                }
            }
            else if (G(questionsQuestionType) == "Etalon")
            {
                answerDataGridView.Visible = false;
                panelAccAnswer.Visible = false;
                panelEtalonAnswer.Visible = true;
            }
            else
            {
                answerDataGridView.Visible = true;
                panelAccAnswer.Visible = false;
                panelEtalonAnswer.Visible = false;
            }

            accordanceLDataGridView.Columns[0].Visible = false;
            accordanceRDataGridView.Columns[0].Visible = false;
        }


        void AccordanceRandom()
        {
            List<string> LText = new List<string>();
            List<int> LReallyAccordance = new List<int>();
            List<System.Drawing.Image> LImg = new List<System.Drawing.Image>();
            List<string> RText = new List<string>();
            List<int> RReallyAccordance = new List<int>();
            List<System.Drawing.Image> RImg = new List<System.Drawing.Image>();
            for (int i = 0; i < accordanceLDataGridView.RowCount; i++)
            {
                LText.Add(accordanceLDataGridView.Rows[i].Cells[1].Value.ToString());
                LReallyAccordance.Add(Convert.ToInt32(accordanceLDataGridView.Rows[i].Cells[2].Value.ToString()));
                if (accordanceLDataGridView.Rows[i].Cells[3].Value != DBNull.Value)
                    LImg.Add(System.Drawing.Image.FromStream(new System.IO.MemoryStream((byte[])accordanceLDataGridView.Rows[i].Cells[3].Value)));
                else
                    LImg.Add(null);
                RText.Add(accordanceRDataGridView.Rows[i].Cells[1].Value.ToString());
                RReallyAccordance.Add(Convert.ToInt32(accordanceRDataGridView.Rows[i].Cells[2].Value.ToString()));
                if (accordanceRDataGridView.Rows[i].Cells[3].Value != DBNull.Value)
                    RImg.Add(System.Drawing.Image.FromStream(new System.IO.MemoryStream((byte[])accordanceRDataGridView.Rows[i].Cells[3].Value)));
                else
                    RImg.Add(null);
            }
            for (int i = 0; i < accordanceLDataGridView.RowCount; i++)
            {
                Random rnd1 = new Random();
                int x = rnd1.Next(0, LText.Count - 1);
                Random rnd2 = new Random();
                int y = rnd2.Next(0, RText.Count - 1);
                accordanceLDataGridView.Rows[i].Cells[1].Value = LText[x];
                accordanceLDataGridView.Rows[i].Cells[2].Value = LReallyAccordance[x];
                accordanceLDataGridView.Rows[i].Cells[3].Value = RImg[x];
                accordanceRDataGridView.Rows[i].Cells[1].Value = RText[y];
                accordanceRDataGridView.Rows[i].Cells[2].Value = RReallyAccordance[y];
                accordanceRDataGridView.Rows[i].Cells[3].Value = RImg[y];
                LText.RemoveAt(x);
                LReallyAccordance.RemoveAt(x);
                LImg.RemoveAt(x);
                RText.RemoveAt(y);
                RReallyAccordance.RemoveAt(y);
                RImg.RemoveAt(y);
            }
        }

        bool startchek = false;
        bool checkLorR = false;
        bool change = false;
        int repeat = 0;
        int Lid;
        int Rid;
        int Rindex1 = -1;
        int Rindex2 = -1;
        Color clr1;
        Color clr2;


        private void accordanceLDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            repeat = 0;
            startchek = true;
            checkLorR = false;
            Lid = e.RowIndex;
        }

        private void accordanceRDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (startchek == true)
            {
                dataGridViewlist.Rows[dataGridViewlist.CurrentRow.Index].DefaultCellStyle.BackColor = Color.FromArgb(0, 177, 89);
                if (Rindex1 == -1)
                {
                    clr1 = accordanceRDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor;
                    if (accordanceRDataGridView.Rows[e.RowIndex].Cells[accordanceRUserAnswer.Name].Value == DBNull.Value)
                        Rindex1 = 0;
                    else
                        Rindex1 = Convert.ToInt32(G(accordanceRUserAnswer, e.RowIndex));
                    change = true;
                }
                else
                {
                    clr2 = accordanceRDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor;
                    if (accordanceRDataGridView.Rows[e.RowIndex].Cells[accordanceRUserAnswer.Name].Value == DBNull.Value)
                        Rindex2 = 0;
                    else
                        Rindex2 = Convert.ToInt32(G(accordanceRUserAnswer, e.RowIndex));
                    change = false;
                }
                accordanceRDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = accordanceLDataGridView.Rows[Lid].DefaultCellStyle.BackColor;
                R(accordanceRUserAnswer, G(accordanceLUserAnswer, Lid), e.RowIndex);
                if (checkLorR == false)
                {
                    checkLorR = true;
                    if ((Rindex1 > -1) && (Rindex2 > -1))
                    {
                        if (change == false)
                            Rindex1 = -1;
                        else
                            Rindex2 = -1;
                    }
                }
                else
                {
                    if (e.RowIndex == Rid)
                        repeat++;
                    if (change == false)
                    {
                        if (((repeat % 2) == 0) || (e.RowIndex == Rid))
                        {
                            accordanceRDataGridView.Rows[Rid].DefaultCellStyle.BackColor = clr1;
                            if (Rindex1 == 0)
                                R(accordanceRUserAnswer, DBNull.Value, Rid);
                            else
                                R(accordanceRUserAnswer, Rindex1, Rid);
                        }
                        if (e.RowIndex != Rid)
                            repeat = 0;
                        Rindex1 = -1;
                    }
                    else
                    {
                        if (((repeat % 2) == 0) || (e.RowIndex == Rid))
                        {
                            accordanceRDataGridView.Rows[Rid].DefaultCellStyle.BackColor = clr2;
                            if (Rindex2 == 0)
                                R(accordanceRUserAnswer, DBNull.Value, Rid);
                            else
                                R(accordanceRUserAnswer, Rindex2, Rid);
                        }
                        if (e.RowIndex != Rid)
                            repeat = 0;
                        Rindex2 = -1;
                    }
                }
                Rid = e.RowIndex;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (Brawl == true)
            {
                SelectNextRandomQ();
            }
            SelectNextQ();
            if (CountOfTrueQuestions(Q()) == 0 && G(questionsQuestionType) != "Accordance")
            {
                MessageBox.Show("В вопросе №" + Convert.ToInt32(Q() + 1) + " не задан верный ответ. Сообщите создателю теста.", "TestCreaTOR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnYes_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete && e.Shift) && TestCreaTOR == true)
            {
                i1 = 1;
            }
        }

        private void btnYes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (i1 == 1)
            {
                Pas += e.KeyChar;
                if (Pas == "TestCreaTOR2018")
                {
                    btnPas.Enabled = true;
                    btnPas.BackColor = Color.Lime;
                    timerPas.Enabled = true;
                    this.Style = MetroFramework.MetroColorStyle.Green;
                    i1 = 0;
                    Pas = "";
                    X = true;
                }
                else
                {
                    if (Pas.Length == 19)
                    {
                        Pas = "";
                        this.Style = MetroFramework.MetroColorStyle.Red;
                        timerPas.Enabled = true;
                    }
                }
            }
        }

        private void btnYes_MouseEnter(object sender, EventArgs e)
        {
            TestCreaTOR = true;
        }

        private void btnYes_MouseLeave(object sender, EventArgs e)
        {
            TestCreaTOR = false;
        }

        private void answerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 4) && (CountOfTrueQuestions(Q()) == 1))
            {
                int ro = answerDataGridView.CurrentRow.Index;
                for (int i = 0; i < answerDataGridView.RowCount; i++)
                {
                    R(answerRadioButton, Properties.Resources.False, i);
                }
                R(answerRadioButton, Properties.Resources.True, ro);
            }
            if (e.ColumnIndex == 4 || e.ColumnIndex == 3)
            {
                dataGridViewlist.Rows[dataGridViewlist.CurrentRow.Index].DefaultCellStyle.BackColor = Color.FromArgb(0, 177, 89);
            }
        }

        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Result.Visible == false)
            {
                e.Cancel = true;
                DialogResult r = MessageBox.Show("Вы не завершили. Подтвердите выход.", "CAVA", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (Properties.Settings.Default.LANG == "BE")
                {
                    r = MessageBox.Show("Вы не завяршылі. Пацвердзіце выхад.", "CAVA", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                }
                if (r == DialogResult.Yes)
                {
                    Saving();
                }
            }
            else
            {
                if (FastMode == false)
                {
                    Form Task = Application.OpenForms["Task"];
                    Task.Enabled = true;
                    Task.Show();
                }
                else
                {
                    Form Task = Application.OpenForms["mini"];
                    Task.Enabled = true;
                    Task.Show();
                }
            }
        }

        bool CheckEmptyAnswers()
        {
            if (TimerSaving == false && Brawl == false && dataGridViewlist.Visible == true)
            {
                string numb_Q;
                numb_Q = "";
                for (int i = 0; i < questionsDataGridView.RowCount; i++)
                {
                    questionsDataGridView.CurrentCell = questionsDataGridView[0, i];
                    if (G(questionsQuestionType, i) == "Accordance")
                    {
                        bool checkaccordance = false;
                        for (int j = 0; j < accordanceRDataGridView.RowCount; j++)
                        {
                            if (accordanceRDataGridView.Rows[j].Cells[accordanceRUserAnswer.Name].Value != DBNull.Value)
                                checkaccordance = true;
                        }
                        if (checkaccordance == false)
                            numb_Q += "№" + (i + 1).ToString() + "  ";
                    }
                    else if (G(questionsQuestionType, i) == "Etalon")
                    {

                    }

                    else if (CountOfTrueQuestions(Q()) == 1)
                    {
                        //Radio
                        bool checkradiobutton = false;
                        for (int j = 0; j < answerDataGridView.RowCount; j++)
                        {
                            if (V(j) == "True")
                                checkradiobutton = true;
                        }
                        if (checkradiobutton == false)
                            numb_Q += "№" + (i + 1).ToString() + "  ";
                    }
                    else
                    {
                        bool checkcheckbox = false;
                        for (int j = 0; j < answerDataGridView.RowCount; j++)
                        {
                            if (V(j) == "True")
                                checkcheckbox = true;
                        }
                        if (checkcheckbox == false)
                            numb_Q += "№" + (i + 1).ToString() + "  ";
                    }
                }

                if (numb_Q.Length == 0)
                {
                    if (MessageBox.Show("Завершить тест ?", "CAVA", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (MessageBox.Show("Вы не ответили на следующие вопросы:   " + numb_Q + " Сохранить данные ?", "CAVA", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int T()
        {
            try
            {
                return testDataGridView.CurrentRow.Index;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        int Q()
        {
            try
            {
                return questionsDataGridView.CurrentRow.Index;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        int A()
        {
            try
            {
                return answerDataGridView.CurrentRow.Index;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        void R(DataGridViewColumn Column, object Text = null, int Row = -1)
        {
            if (Row == -1)
            {
                if (Column.DataGridView.RowCount >= Column.DataGridView.CurrentRow.Index &&
                Column.DataGridView.CurrentRow.Index >= 0)
                    Column.DataGridView.Rows[Column.DataGridView.CurrentRow.Index].Cells[Column.Name].Value = Text;
            }
            else
            {
                if (Column.DataGridView.RowCount >= Row && Row >= 0)
                    Column.DataGridView.Rows[Row].Cells[Column.Name].Value = Text;
            }
            Column.DataGridView.EndEdit();
            ((BindingSource)Column.DataGridView.DataSource).EndEdit();
        }

        string G(DataGridViewColumn Column, int Row = -1)
        {
            if (Row == -1)
            {
                if (Column.DataGridView.RowCount >= Column.DataGridView.CurrentRow.Index &&
                Column.DataGridView.CurrentRow.Index >= 0)
                    return Column.DataGridView.Rows[Column.DataGridView.CurrentRow.Index].Cells[Column.Name].Value.ToString();
                else
                    return "";
            }
            else
            {

                if (Column.DataGridView.RowCount >= Row && Row >= 0)
                    return Column.DataGridView.Rows[Row].Cells[Column.Name].Value.ToString();
                else
                    return "";
            }
        }

        private void questionsDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (Loaded == true)
            //{
            //    if (G(questionsResultsTime, Q()) == "")
            //        R(questionsResultsTime, 0, Q());
            //    else
            //    {
            //        R(questionsResultsTime, Convert.ToInt32(Convert.ToInt32(G(questionsResultsTime)) + 1), Q());
            //    }
            //}
        }

        private void dataGridViewlist_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewlist.CurrentRow.Index <= questionsDataGridView.RowCount - 1)
            {
                questionsDataGridView.CurrentCell = questionsDataGridView[0, dataGridViewlist.CurrentRow.Index];
                SetQuestionType();
                SetQuestionCost();
            }
            if (e.RowIndex == dataGridViewlist.RowCount - 1)
            {
                Saving();
            }
        }
    }
}