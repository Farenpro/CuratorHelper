using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace CuratorHelper.Classes
{
    public static class SubFunctions
    {
        const int ExcelDisciplineStartColumn = 8;
        const int ExcelStudentColumn = 2;
        const int ExcelStudentCountColumn = 1;
        const int ExcelDisciplineRow = 3;
        const int ExcelStudentStartRow = 3;
        const int ExcelOmissionsAllRespectColumn = 27;
        const int ExcelOmissionsAllDisrespectColumn = 28;
        const int ExcelOmissionsAllColumn = 26;
        const int ExcelStudentBehaviourColumn = 29;
        public static void TBShowHide(TextBox tbox, PasswordBox pbox, bool check)
        {
            if (check)
            {
                tbox.Text = pbox.Password;
                pbox.Clear();
                tbox.Visibility = Visibility.Visible;
                pbox.Visibility = Visibility.Collapsed;
            }
            else
            {
                pbox.Password = tbox.Text;
                tbox.Text = string.Empty;
                tbox.Visibility = Visibility.Collapsed;
                pbox.Visibility = Visibility.Visible;
            }
        }
        public static void ShowEditWindow(byte type)
        {
            EditInfoWindow editInfoWindow = new EditInfoWindow(type);
            editInfoWindow.ShowDialog();
        }
        public static void ShowEditWindow(Student student, byte type)
        {
            EditInfoWindow editInfoWindow = new EditInfoWindow(student, type);
            editInfoWindow.ShowDialog();
        }

        public static void OutputStatement(byte? Term)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources");
            path = $"{path}\\Успеваемость ШАБЛОН.xlsx";
            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Add(path);
            Excel.Worksheet worksheet = app.Worksheets[1];
            List<Discipline> disciplines = new List<Discipline>();
            List<Student> students = new List<Student>();
            worksheet.Cells[24][1] = $"Группа {App.CurGroup.Name}";
            string arabTerm = string.Empty;
            string year = string.Empty;
            int groupStartStudyYear = App.CurGroup.StartStudyDate.Year;
            switch (Term)
            {
                case 1:
                    arabTerm = "I";
                    year = $"{groupStartStudyYear}/{groupStartStudyYear + 1}";
                    break;
                case 2:
                    arabTerm = "II";
                    year = $"{groupStartStudyYear}/{groupStartStudyYear + 1}";
                    break;
                case 3:
                    arabTerm = "III";
                    year = $"{groupStartStudyYear + 1}/{groupStartStudyYear + 2}";
                    break;
                case 4:
                    arabTerm = "IV";
                    year = $"{groupStartStudyYear + 1}/{groupStartStudyYear + 2}";
                    break;
                case 5:
                    arabTerm = "V";
                    year = $"{groupStartStudyYear + 2}/{groupStartStudyYear + 3}";
                    break;
                case 6:
                    arabTerm = "VI";
                    year = $"{groupStartStudyYear + 2}/{groupStartStudyYear + 3}";
                    break;
                case 7:
                    arabTerm = "VII";
                    year = $"{groupStartStudyYear + 3}/{groupStartStudyYear + 4}";
                    break;
                case 8:
                    arabTerm = "VIII";
                    year = $"{groupStartStudyYear + 3}/{groupStartStudyYear + 4}";
                    break;
            }
            worksheet.Cells[5][1] = $"ИТОГИ УСПЕВАЕМОСТИ И ПОСЕЩАЕМОСТИ ЗА {arabTerm} СЕМЕСТР {year} учебного года";
            worksheet.Cells[16][43] = App.CurGroup.CuratorName;
            if (!FillDisciplines(Term, worksheet, out disciplines))
                App.Messages.ShowInfo(Properties.Resources.DisciplinesError);
            if (!FillStudents(Term, worksheet, out students))
                App.Messages.ShowInfo(Properties.Resources.StudentsError);
            FillStudentMarks(Term, worksheet, disciplines, students);
            FillOmissions(Term, worksheet, students);
            app.Visible = true;
        }

        public static void FormPersonalCard(Student student)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources");
            path = $"{path}\\Личная карточка ШАБЛОН.docx";
            Word.Application app = new Word.Application();
            Word.Document document = app.Documents.Add(path);
            Order credited = App.Database.Orders.Where(p => p.StudentID == student.ID && p.OrderType.Name == "Зачисление").FirstOrDefault();
            document.Bookmarks["StudentFIO"].Range.Text = student.FIO;
            string schoolinfo = string.Empty;
            if (credited != null)
            {
                document.Bookmarks["EnrolledCourse"].Range.Text = credited.Course.ToString();
                document.Bookmarks["EnrolledDay"].Range.Text = credited.Date.ToString("dd");
                document.Bookmarks["EnrolledMonth"].Range.Text = credited.Date.ToString("MMM");
                document.Bookmarks["EnrolledYear"].Range.Text = credited.Date.ToString("yyyy");
                document.Bookmarks["OrderNumDate"].Range.Text = credited.FullInfo;
            }
            document.Bookmarks["StudentGroup"].Range.Text = student.GroupName;
            document.Bookmarks["SpecializationCodeName"].Range.Text = student.SpecializationName;
            document.Bookmarks["StudentFIO2"].Range.Text = student.FIO;
            document.Bookmarks["Gender"].Range.Text = student.GenderName;
            if (student.Birthdate != null)
                document.Bookmarks["BirthdateString"].Range.Text = student.Birthdate.Value.ToString("dd MM yyyy");
            if (student.BirthPlace != null)
                document.Bookmarks["BirthPlace"].Range.Text = student.BirthPlace;
            if (student.GuardianAddress != null)
                document.Bookmarks["GuardianAddress"].Range.Text = student.GuardianAddress;
            if (student.CompletedClassesID != null)
                schoolinfo += $"Закончил {student.CompletedClassesID} классов ";
            if (student.SchoolGraduateDate != null)
                schoolinfo += $"в {student.SchoolGraduateDate.Value.ToString("yyyy")} году. ";
            if (student.SchoolName != null)
                schoolinfo += student.SchoolName;
            document.Bookmarks["SchoolNameFinishedDateAndClasses"].Range.Text = schoolinfo;
            Order order2 = App.Database.Orders.Where(p => p.StudentID == student.ID && p.OrderType.Name == "Перевод на другой курс" && p.Course == 2).FirstOrDefault();
            if (order2 != null)
                document.Bookmarks["Order2Course"].Range.Text = order2.FullInfo;
            Order order3 = App.Database.Orders.Where(p => p.StudentID == student.ID && p.OrderType.Name == "Перевод на другой курс" && p.Course == 3).FirstOrDefault();
            if (order3 != null)
                document.Bookmarks["Order3Course"].Range.Text = order3.FullInfo;
            Order order4 = App.Database.Orders.Where(p => p.StudentID == student.ID && p.OrderType.Name == "Перевод на другой курс" && p.Course == 4).FirstOrDefault();
            if (order4 != null)
                document.Bookmarks["Order4Course"].Range.Text = order4.FullInfo;
            Order ordergraduate = App.Database.Orders.Where(p => p.StudentID == student.ID && p.OrderType.Name == "Выпуск").FirstOrDefault();
            if (ordergraduate != null)
                document.Bookmarks["OrderGraduateCourse"].Range.Text = ordergraduate.FullInfo;
            if (student.AimedAt != null)
                document.Bookmarks["AimedAt"].Range.Text = student.AimedAt;
            List<Credit> marks = App.Database.Credits.Where(p => p.StudentID == student.ID).ToList();
            if (marks.Count() > 0)
            {
                Word.Table marksTable = document.Tables.Add(document.Bookmarks["StatementTable"].Range, marks.Count() + 2, 10);
                marksTable.AllowAutoFit = true;
                marksTable.Cell(1, 1).Merge(marksTable.Cell(2, 1));
                marksTable.Cell(1, 2).Merge(marksTable.Cell(2, 2));
                marksTable.Cell(1, 3).Merge(marksTable.Cell(1, 4));
                marksTable.Cell(1, 4).Merge(marksTable.Cell(1, 5));
                marksTable.Cell(1, 5).Merge(marksTable.Cell(1, 6));
                marksTable.Cell(1, 6).Merge(marksTable.Cell(1, 7));
                marksTable.Cell(1, 1).Range.Text = "№№";
                marksTable.Cell(1, 2).Range.Text = "Наименование дисциплин, МДК И ПМ";
                marksTable.Cell(1, 3).Range.Text = "1 курс";
                marksTable.Cell(1, 4).Range.Text = "2 курс";
                marksTable.Cell(1, 5).Range.Text = "3 курс";
                marksTable.Cell(1, 6).Range.Text = "4 курс";
                marksTable.Cell(2, 3).Range.Text = "1 семестр";
                marksTable.Cell(2, 4).Range.Text = "2 семестр";
                marksTable.Cell(2, 5).Range.Text = "3 семестр";
                marksTable.Cell(2, 6).Range.Text = "4 семестр";
                marksTable.Cell(2, 7).Range.Text = "5 семестр";
                marksTable.Cell(2, 8).Range.Text = "6 семестр";
                marksTable.Cell(2, 9).Range.Text = "7 семестр";
                marksTable.Cell(2, 10).Range.Text = "8 семестр";
                marksTable.Borders.InsideLineStyle = marksTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                for (int i = 1; i <= marks.Count(); i++)
                {
                    if (marks[i - 1].Discipline.DisciplineIndex != null)
                        marksTable.Cell(i + 2, 1).Range.Text = marks[i - 1].Discipline.IndexName;
                    else
                        marksTable.Cell(i + 2, 1).Range.Text = $"{i}.";
                    marksTable.Cell(i + 2, 2).Range.Text = marks[i - 1].Discipline.ObjectName;
                    marksTable.Cell(i + 2, 3).Range.Text = marks[i - 1].Term1Mark.ToString();
                    marksTable.Cell(i + 2, 4).Range.Text = marks[i - 1].Term2Mark.ToString();
                    marksTable.Cell(i + 2, 5).Range.Text = marks[i - 1].Term3Mark.ToString();
                    marksTable.Cell(i + 2, 6).Range.Text = marks[i - 1].Term4Mark.ToString();
                    marksTable.Cell(i + 2, 7).Range.Text = marks[i - 1].Term5Mark.ToString();
                    marksTable.Cell(i + 2, 8).Range.Text = marks[i - 1].Term6Mark.ToString();
                    marksTable.Cell(i + 2, 9).Range.Text = marks[i - 1].Term7Mark.ToString();
                    marksTable.Cell(i + 2, 10).Range.Text = marks[i - 1].Term8Mark.ToString();
                }
            }
            List<Practice> practices = App.Database.Practices.Where(p => p.StudentID == student.ID).ToList();
            if (practices.Count() > 0)
            {
                Word.Table practicesTable = document.Tables.Add(document.Bookmarks["StudentPracticsTable"].Range, practices.Count() + 1, 5);
                practicesTable.AllowAutoFit = true;
                practicesTable.Cell(1, 1).Range.Text = "№№";
                practicesTable.Cell(1, 2).Range.Text = "Наименование вида практики";
                practicesTable.Cell(1, 3).Range.Text = "Курс, семестр";
                practicesTable.Cell(1, 4).Range.Text = "Продолжительность";
                practicesTable.Cell(1, 5).Range.Text = "Оценка";
                practicesTable.Borders.InsideLineStyle = practicesTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                for (int i = 1; i <= practices.Count(); i++)
                {
                    practicesTable.Cell(i + 1, 1).Range.Text = $"{i}.";
                    practicesTable.Cell(i + 1, 2).Range.Text = practices[i - 1].PracticeName.Name;
                    practicesTable.Cell(i + 1, 3).Range.Text = $"{practices[i - 1].Term} семестр";
                    practicesTable.Cell(i + 1, 4).Range.Text = practices[i - 1].DaysDuration.ToString();
                    practicesTable.Cell(i + 1, 5).Range.Text = practices[i - 1].Mark.ToString();
                }
            }
            Omission resp = App.Database.Omissions.Where(p => p.StudentID == student.ID && p.OmissionType.Name == "По уважительной причине").FirstOrDefault();
            Omission disresp = App.Database.Omissions.Where(p => p.StudentID == student.ID && p.OmissionType.Name == "По неуважительной причине").FirstOrDefault();
            if (resp != null)
            {
                document.Bookmarks["StudOMSRespect1Term"].Range.Text = resp.Term1Count.ToString();
                document.Bookmarks["StudOMSRespect2Term"].Range.Text = resp.Term2Count.ToString();
                document.Bookmarks["StudOMSRespect3Term"].Range.Text = resp.Term3Count.ToString();
                document.Bookmarks["StudOMSRespect4Term"].Range.Text = resp.Term4Count.ToString();
                document.Bookmarks["StudOMSRespect5Term"].Range.Text = resp.Term5Count.ToString();
                document.Bookmarks["StudOMSRespect6Term"].Range.Text = resp.Term6Count.ToString();
                document.Bookmarks["StudOMSRespect7Term"].Range.Text = resp.Term7Count.ToString();
                document.Bookmarks["StudOMSRespect8Term"].Range.Text = resp.Term8Count.ToString();
                int summ = resp.Term1Count.GetValueOrDefault() + resp.Term2Count.GetValueOrDefault() + resp.Term3Count.GetValueOrDefault() +
                    resp.Term4Count.GetValueOrDefault() + resp.Term5Count.GetValueOrDefault() + resp.Term6Count.GetValueOrDefault() + resp.Term7Count.GetValueOrDefault() +
                    resp.Term8Count.GetValueOrDefault();
                document.Bookmarks["StudOMSRespectAll"].Range.Text = summ.ToString();
            }
            if (disresp != null)
            {
                document.Bookmarks["StudOMSDisrespect1Term"].Range.Text = disresp.Term1Count.ToString();
                document.Bookmarks["StudOMSDisrespect2Term"].Range.Text = disresp.Term2Count.ToString();
                document.Bookmarks["StudOMSDisrespect3Term"].Range.Text = disresp.Term3Count.ToString();
                document.Bookmarks["StudOMSDisrespect4Term"].Range.Text = disresp.Term4Count.ToString();
                document.Bookmarks["StudOMSDisrespect5Term"].Range.Text = disresp.Term5Count.ToString();
                document.Bookmarks["StudOMSDisrespect6Term"].Range.Text = disresp.Term6Count.ToString();
                document.Bookmarks["StudOMSDisrespect7Term"].Range.Text = disresp.Term7Count.ToString();
                document.Bookmarks["StudOMSDisrespect8Term"].Range.Text = disresp.Term8Count.ToString();
                int summ = disresp.Term1Count.GetValueOrDefault() + disresp.Term2Count.GetValueOrDefault() + disresp.Term3Count.GetValueOrDefault() +
                    disresp.Term4Count.GetValueOrDefault() + disresp.Term5Count.GetValueOrDefault() + disresp.Term6Count.GetValueOrDefault() + disresp.Term7Count.GetValueOrDefault() +
                    disresp.Term8Count.GetValueOrDefault();
                document.Bookmarks["StudOMSDisrespectAll"].Range.Text = summ.ToString();
            }
            GraduateWork graduateWork = App.Database.GraduateWorks.Where(p => p.StudentID == student.ID).FirstOrDefault();
            if (graduateWork != null)
            {
                document.Bookmarks["GraduateWorkTypeName"].Range.Text = graduateWork.GraduateWorkType.Name;
                document.Bookmarks["GraduateWorkTheme"].Range.Text = graduateWork.Name;
                document.Bookmarks["GraduateWorkProtectDate"].Range.Text = graduateWork.ProtectDateNoTime;
                document.Bookmarks["GraduateWorkGEKMark"].Range.Text = graduateWork.Mark.ToString();
                document.Bookmarks["StudentQualification"].Range.Text = graduateWork.Qualification.Name;
            }
            List<DemoExam> demoExams = App.Database.DemoExams.Where(p => p.StudentID == student.ID).ToList();
            if (demoExams.Count() > 0)
            {
                Word.Table demoExamsTable = document.Tables.Add(document.Bookmarks["DemoExamsTable"].Range, demoExams.Count() + 1, 3);
                demoExamsTable.AllowAutoFit = true;
                demoExamsTable.Cell(1, 1).Range.Text = "№№";
                demoExamsTable.Cell(1, 2).Range.Text = "Наименование";
                demoExamsTable.Cell(1, 3).Range.Text = "Оценка";
                demoExamsTable.Borders.InsideLineStyle = demoExamsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                for (int i = 1; i <= demoExams.Count(); i++)
                {
                    demoExamsTable.Cell(i + 1, 1).Range.Text = $"{i}.";
                    demoExamsTable.Cell(i + 1, 2).Range.Text = demoExams[i - 1].DemoExamName.Name;
                    demoExamsTable.Cell(i + 1, 3).Range.Text = demoExams[i - 1].Mark.ToString();
                }
            }
            document.Bookmarks["StudentCommunityService"].Range.Text = student.CommunityService;
            List<PenAndInc> pens = App.Database.PenAndIncs.Where(p => p.StudentID == student.ID && p.PenAndIncType.Name == "Взыскание").ToList();
            List<PenAndInc> incs = App.Database.PenAndIncs.Where(p => p.StudentID == student.ID && p.PenAndIncType.Name == "Поощрение").ToList();
            if (pens.Count() > 0 || incs.Count() > 0)
            {
                Word.Table penAndIncsTable = document.Tables.Add(document.Bookmarks["StudentPenAndIncTable"].Range, pens.Count() + incs.Count() + 2, 4);
                penAndIncsTable.AllowAutoFit = true;
                penAndIncsTable.Cell(1, 1).Merge(penAndIncsTable.Cell(1, 2));
                penAndIncsTable.Cell(1, 2).Merge(penAndIncsTable.Cell(1, 3));
                penAndIncsTable.Cell(1, 1).Range.Text = "Взыскания";
                penAndIncsTable.Cell(1, 2).Range.Text = "Поощрения";
                penAndIncsTable.Cell(2, 1).Range.Text = "Характер взыскания";
                penAndIncsTable.Cell(2, 2).Range.Text = "№ и дата приказа";
                penAndIncsTable.Cell(2, 3).Range.Text = "Характер поощрения";
                penAndIncsTable.Cell(2, 4).Range.Text = "№ и дата приказа";
                penAndIncsTable.Borders.InsideLineStyle = penAndIncsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                if (pens.Count() > 0)
                {
                    for (int i = 1; i <= pens.Count(); i++)
                    {
                        penAndIncsTable.Cell(i + 2, 1).Range.Text = pens[i - 1].Nature;
                        penAndIncsTable.Cell(i + 2, 2).Range.Text = pens[i - 1].OrderInfo;
                    }
                }
                if (incs.Count() > 0)
                {
                    for (int i = 1; i <= incs.Count(); i++)
                    {
                        penAndIncsTable.Cell(i + 2, 3).Range.Text = incs[i - 1].Nature;
                        penAndIncsTable.Cell(i + 2, 4).Range.Text = incs[i - 1].OrderInfo;
                    }
                }
            }
            app.Visible = true;
        }

        private static bool FillDisciplines(byte? term, Excel.Worksheet worksheet, out List<Discipline> disciplines)
        {
            disciplines = new List<Discipline>();
            switch (term)
            {
                case 1:
                    disciplines = App.Database.Credits.Where(p => p.Student.GroupID == App.CurGroup.ID && p.Term1Mark != null && p.Discipline.Object.Name != "Поведение").Select(p => p.Discipline).Distinct().ToList();
                    break;
                case 2:
                    disciplines = App.Database.Credits.Where(p => p.Student.GroupID == App.CurGroup.ID && p.Term2Mark != null && p.Discipline.Object.Name != "Поведение").Select(p => p.Discipline).Distinct().ToList();
                    break;
                case 3:
                    disciplines = App.Database.Credits.Where(p => p.Student.GroupID == App.CurGroup.ID && p.Term3Mark != null && p.Discipline.Object.Name != "Поведение").Select(p => p.Discipline).Distinct().ToList();
                    break;
                case 4:
                    disciplines = App.Database.Credits.Where(p => p.Student.GroupID == App.CurGroup.ID && p.Term4Mark != null && p.Discipline.Object.Name != "Поведение").Select(p => p.Discipline).Distinct().ToList();
                    break;
                case 5:
                    disciplines = App.Database.Credits.Where(p => p.Student.GroupID == App.CurGroup.ID && p.Term5Mark != null && p.Discipline.Object.Name != "Поведение").Select(p => p.Discipline).Distinct().ToList();
                    break;
                case 6:
                    disciplines = App.Database.Credits.Where(p => p.Student.GroupID == App.CurGroup.ID && p.Term6Mark != null && p.Discipline.Object.Name != "Поведение").Select(p => p.Discipline).Distinct().ToList();
                    break;
                case 7:
                    disciplines = App.Database.Credits.Where(p => p.Student.GroupID == App.CurGroup.ID && p.Term7Mark != null && p.Discipline.Object.Name != "Поведение").Select(p => p.Discipline).Distinct().ToList();
                    break;
                case 8:
                    disciplines = App.Database.Credits.Where(p => p.Student.GroupID == App.CurGroup.ID && p.Term8Mark != null && p.Discipline.Object.Name != "Поведение").Select(p => p.Discipline).Distinct().ToList();
                    break;
            }
            if (disciplines.Count() >= 1 && disciplines.Count <= 14)
            {
                for (int i = 1; i <= disciplines.Count; i++)
                    worksheet.Cells[ExcelDisciplineStartColumn + i][ExcelDisciplineRow] = disciplines[i - 1].IndexAndName;
                return true;
            }
            else return false;
        }

        private static bool FillStudents(byte? term, Excel.Worksheet worksheet, out List<Student> students)
        {
            students = App.Database.Students.Where(p => p.GroupID == App.CurGroup.ID).ToList();
            if (students.Count() >= 1 && students.Count <= 30)
            {
                for (int i = 1; i <= students.Count; i++)
                {
                    worksheet.Cells[ExcelStudentCountColumn][ExcelStudentStartRow + i] = i;
                    worksheet.Cells[ExcelStudentColumn][ExcelStudentStartRow + i] = students[i - 1].FIO;
                }
                return true;
            }
            else return false;
        }

        private static void FillStudentMarks(byte? term, Excel.Worksheet worksheet, List<Discipline> disciplines, List<Student> students)
        {
            if (students.Count() >= 1 && disciplines.Count >= 1)
            {
                for (int i = 1; i <= disciplines.Count; i++)
                {
                    for (int j = 1; j <= students.Count; j++)
                    {
                        Credit credit = App.Database.Credits.ToList().Where(p => p.StudentID == students[j - 1].ID && p.DisciplineID == disciplines[i - 1].ID).FirstOrDefault();
                        if (credit != null)
                        {
                            switch (term)
                            {
                                case 1:
                                    worksheet.Cells[ExcelDisciplineStartColumn + i][ExcelDisciplineRow + j] = credit.Term1Mark;
                                    break;
                                case 2:
                                    worksheet.Cells[ExcelDisciplineStartColumn + i][ExcelDisciplineRow + j] = credit.Term2Mark;
                                    break;
                                case 3:
                                    worksheet.Cells[ExcelDisciplineStartColumn + i][ExcelDisciplineRow + j] = credit.Term3Mark;
                                    break;
                                case 4:
                                    worksheet.Cells[ExcelDisciplineStartColumn + i][ExcelDisciplineRow + j] = credit.Term4Mark;
                                    break;
                                case 5:
                                    worksheet.Cells[ExcelDisciplineStartColumn + i][ExcelDisciplineRow + j] = credit.Term5Mark;
                                    break;
                                case 6:
                                    worksheet.Cells[ExcelDisciplineStartColumn + i][ExcelDisciplineRow + j] = credit.Term6Mark;
                                    break;
                                case 7:
                                    worksheet.Cells[ExcelDisciplineStartColumn + i][ExcelDisciplineRow + j] = credit.Term7Mark;
                                    break;
                                case 8:
                                    worksheet.Cells[ExcelDisciplineStartColumn + i][ExcelDisciplineRow + j] = credit.Term8Mark;
                                    break;
                            }
                        }
                        Credit creditbehaviour = App.Database.Credits.ToList().Where(p => p.StudentID == students[j - 1].ID && p.Discipline.Object.Name == "Поведение").FirstOrDefault();
                        if (creditbehaviour != null)
                        {
                            switch (term)
                            {
                                case 1:
                                    worksheet.Cells[ExcelStudentBehaviourColumn][ExcelDisciplineRow + j] = creditbehaviour.Term1Mark;
                                    break;
                                case 2:
                                    worksheet.Cells[ExcelStudentBehaviourColumn][ExcelDisciplineRow + j] = creditbehaviour.Term2Mark;
                                    break;
                                case 3:
                                    worksheet.Cells[ExcelStudentBehaviourColumn][ExcelDisciplineRow + j] = creditbehaviour.Term3Mark;
                                    break;
                                case 4:
                                    worksheet.Cells[ExcelStudentBehaviourColumn][ExcelDisciplineRow + j] = creditbehaviour.Term4Mark;
                                    break;
                                case 5:
                                    worksheet.Cells[ExcelStudentBehaviourColumn][ExcelDisciplineRow + j] = creditbehaviour.Term5Mark;
                                    break;
                                case 6:
                                    worksheet.Cells[ExcelStudentBehaviourColumn][ExcelDisciplineRow + j] = creditbehaviour.Term6Mark;
                                    break;
                                case 7:
                                    worksheet.Cells[ExcelStudentBehaviourColumn][ExcelDisciplineRow + j] = creditbehaviour.Term7Mark;
                                    break;
                                case 8:
                                    worksheet.Cells[ExcelStudentBehaviourColumn][ExcelDisciplineRow + j] = creditbehaviour.Term8Mark;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private static void FillOmissions(byte? term, Excel.Worksheet worksheet, List<Student> students)
        {
            for (int i = 1; i <= students.Count; i++)
            {
                Omission respect = App.Database.Omissions.ToList().Where(p => p.StudentID == students[i - 1].ID && p.OmissionType.Name == "По уважительной причине").FirstOrDefault();
                Omission disrespect = App.Database.Omissions.ToList().Where(p => p.StudentID == students[i - 1].ID && p.OmissionType.Name == "По неуважительной причине").FirstOrDefault();
                switch (term)
                {
                    case 1:
                        if (respect != null)
                            worksheet.Cells[ExcelOmissionsAllRespectColumn][ExcelStudentStartRow + i] = respect.Term1Count.GetValueOrDefault();
                        if (disrespect != null)
                            worksheet.Cells[ExcelOmissionsAllDisrespectColumn][ExcelStudentStartRow + i] = disrespect.Term1Count.GetValueOrDefault();
                        break;
                    case 2:
                        if (respect != null)
                            worksheet.Cells[ExcelOmissionsAllRespectColumn][ExcelStudentStartRow + i] = respect.Term2Count.GetValueOrDefault();
                        if (disrespect != null)
                            worksheet.Cells[ExcelOmissionsAllDisrespectColumn][ExcelStudentStartRow + i] = disrespect.Term2Count.GetValueOrDefault();
                        break;
                    case 3:
                        if (respect != null)
                            worksheet.Cells[ExcelOmissionsAllRespectColumn][ExcelStudentStartRow + i] = respect.Term3Count.GetValueOrDefault();
                        if (disrespect != null)
                            worksheet.Cells[ExcelOmissionsAllDisrespectColumn][ExcelStudentStartRow + i] = disrespect.Term3Count.GetValueOrDefault();
                        break;
                    case 4:
                        if (respect != null)
                            worksheet.Cells[ExcelOmissionsAllRespectColumn][ExcelStudentStartRow + i] = respect.Term4Count.GetValueOrDefault();
                        if (disrespect != null)
                            worksheet.Cells[ExcelOmissionsAllDisrespectColumn][ExcelStudentStartRow + i] = disrespect.Term4Count.GetValueOrDefault();
                        break;
                    case 5:
                        if (respect != null)
                            worksheet.Cells[ExcelOmissionsAllRespectColumn][ExcelStudentStartRow + i] = respect.Term5Count.GetValueOrDefault();
                        if (disrespect != null)
                            worksheet.Cells[ExcelOmissionsAllDisrespectColumn][ExcelStudentStartRow + i] = disrespect.Term5Count.GetValueOrDefault();
                        break;
                    case 6:
                        if (respect != null)
                            worksheet.Cells[ExcelOmissionsAllRespectColumn][ExcelStudentStartRow + i] = respect.Term6Count.GetValueOrDefault();
                        if (disrespect != null)
                            worksheet.Cells[ExcelOmissionsAllDisrespectColumn][ExcelStudentStartRow + i] = disrespect.Term6Count.GetValueOrDefault();
                        break;
                    case 7:
                        if (respect != null)
                            worksheet.Cells[ExcelOmissionsAllRespectColumn][ExcelStudentStartRow + i] = respect.Term7Count.GetValueOrDefault();
                        if (disrespect != null)
                            worksheet.Cells[ExcelOmissionsAllDisrespectColumn][ExcelStudentStartRow + i] = disrespect.Term7Count.GetValueOrDefault();
                        break;
                    case 8:
                        if (respect != null)
                            worksheet.Cells[ExcelOmissionsAllRespectColumn][ExcelStudentStartRow + i] = respect.Term8Count.GetValueOrDefault();
                        if (disrespect != null)
                            worksheet.Cells[ExcelOmissionsAllDisrespectColumn][ExcelStudentStartRow + i] = disrespect.Term8Count.GetValueOrDefault();
                        break;
                }
            }
        }
    }
}
