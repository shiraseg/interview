הרצת התוכנית: F5.
הלקוח רואה את עמוד הבית אליו יכול לחזור תמיד על ידי לחיצה על טאב HOME. (כל הטאבים הם חלק מהLAYOUT שהלקוח רואה במשך כל זמן ההרצה)
![image](https://github.com/shiraseg/interview/assets/92149110/33604bfd-35d6-4244-b986-e3a4b03ee287)

ללקוח יש אפשרות לראות רשימה של כל הלקוחות, דוחות לגבי חולים ומחוסנים ולייצר לקוח חדש.
![image](https://github.com/shiraseg/interview/assets/92149110/4dfed9ce-3b67-4869-8ed9-e2cc16a674d3)

ברשימה של כל החולים בקופת החולים יש מידע מסונן ורלוונטי, ליד כל אחד מהפריטים יש אופציה לראות מידע נוסף שלא מוצג ברשימה הכוללת. כמו כן יש יכולץ לערוך לקוח, למחוק לקוח.
בעמוד זה יש אופציה של סינון לפי תעודת זהות של לקוח (שלימה או חלקית) כמו בדוגמה:
![image](https://github.com/shiraseg/interview/assets/92149110/a0676bd5-028c-4bf8-806a-b7ed25b19b93)

הוספת לקוח חדש:
עבור הוספת חיסון יש אופציה של הוספה עד מקסימום 4 חיסונים.
עבור הוספה של סטטוס מחלה - אין הגבלה
אם אין לנו רצון להוסיף חיסון או סטטוס מחלה - לא ניגע בתיבה המיועדת והערכים יהיו שם NULL וממילא לא יתווספו.
![image](https://github.com/shiraseg/interview/assets/92149110/b574f21a-09a7-4d8c-81ac-2dfe3762eaab)

בטאבים יש גם אופציה של לראות דוחות REPORTS על הנעשה בחודש האחרון:
![image](https://github.com/shiraseg/interview/assets/92149110/251c7df1-50e0-4459-9f52-5dcf605e87cd)


השתמשתי בטכנולוגית ASP.NET CORE בארכיטקטורת MVC. ובמסד נתונית SQLSERVER של MICROSOFT
על מנת לייצר את מסד הנתונים היה עלי לייצר מחלקה DbContext וכן לבצע Inject לבניה של מסד הנתונים.
החלטתי שעיצובית נכון לי לייצר מודל PERSON שלמודל זה יהיה שדה של רשימת חיסונים ושדה של רשימת סטטוס מחלה.
שדות אלו יהיו virtual ולא ישמרו בDATABASE על מנת לא להעמיס את טבלת הPERSON, אך המשמעות שלהן היא שבזמן הרצה אוכל לשמור רשימה מעודכנת של חיסונים וסטטוס מחלה משויכים ללקוח ספציפי.

ייצרתי מודל COVIDSTATUS ששומר תאריך של תחילת מחלת הקורונה ותאריך ההחלמה. יש לו FORGEIN KEY המשויך לPERSON.
ייצרתי מודל VACCINATION ששומר את סוג החיסון (מסוג ENUM) ואת תאריך קבלת החיסון. גם לו יש FORGEIN KEY המשויך לPERSON.

ייצרתי קוטרולר לPERSON שבו יש רפרנס לכל פעולות CRUD.


