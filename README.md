# Driving-License-Management-System-DVLD---Desktop-Application

📄 Driving License Management System (DVLD) - Desktop Application

📌 OverviewThe

Driving & Vehicle License Department (DVLD) system is a comprehensive desktop application designed to automate and manage the entire lifecycle of driving licenses. 

This project is part of a specialized curriculum led by Eng. Mohammed Abu-Hadhoud, focusing on building robust, real-world enterprise applications using C# and SQL Server.

🚀 Key Features

Application Management: Handles various service types including new licenses, renewals, and replacements for lost or damaged licenses.

Multi-Stage Testing Workflow: Implements a strict sequential testing process: Vision Test, Theory Test, and Practical Street Test.

International Licenses: Supports the issuance of international driving permits based on existing local licenses.

Detained License System: A dedicated module for detaining licenses, managing fines, and processing releases.

User & People Management: A centralized system to manage personal records and system users with specific permission levels.

Comprehensive Database Design: A highly normalized relational schema ensuring data integrity and performance.

🛠️ Technologies Used


Programming Language: C# (.NET Framework)

Database: Microsoft SQL Server (T-SQL)

Architecture: Layered Architecture (Data Access, Business Logic, and UI Layers)

UI/UX: Windows Forms (WinForms)

📊 Database Design


The system relies on a complex relational model that separates personal identity from professional driving records.

Centralized Person Table: Links to both Users and Drivers to prevent data redundancy.

Application-Centric Logic: Every service (New, Renew, Release) is tracked through an Applications table for financial and administrative auditing.



📄 نظام إدارة رخص القيادة (DVLD) - تطبيق لسطح المكتب

📌 نظرة عامة 

يعد نظام إدارة ترخيص السواقين والمركبات (DVLD) تطبيقاً متكاملاً لسطح المكتب تم تصميمه لأتمتة وإدارة دورة حياة رخص القيادة بالكامل. هذا المشروع هو جزء من المنهج التعليمي المتخصص للأستاذ محمد أبو هدهود، ويركز على بناء تطبيقات برمجية قوية تحاكي الأنظمة الحقيقية باستخدام لغة C# وقواعد بيانات SQL Server.

🚀الميزات الأساسية

إدارة الطلبات: التعامل مع أنواع مختلفة من الخدمات بما في ذلك إصدار رخص جديدة، التجديد، وإصدار بدل فاقد أو تالف.

سير عمل الاختبارات المتسلسل: يطبق النظام عملية اختبار صارمة تشمل: فحص النظر، الاختبار النظري، واختبار القيادة العملي.

الرخص الدولية: يدعم إصدار تصاريح القيادة الدولية بناءً على رخص القيادة المحلية السارية.

نظام حجز الرخص: وحدة مخصصة لحجز الرخص، إدارة الغرامات، ومعالجة عمليات فك الحجز.

إدارة المستخدمين والأشخاص: نظام مركزي لإدارة السجلات الشخصية ومستخدمي النظام مع مستويات صلاحيات محددة.

تصميم قاعدة بيانات شامل: مخطط علائقي منظم بعناية يضمن سلامة البيانات وكفاءة الأداء.


🛠️ التقنيات المستخدمة 

لغة البرمجة: C# (.NET Framework)

قاعدة البيانات: Microsoft SQL Server (T-SQL)

المعمارية: معمارية الطبقات (Layered Architecture) - (Data Access, Business Logic, and UI Layers).

واجهة المستخدم: Windows Forms (WinForms)


📊 تصميم قاعدة البيانات 

يعتمد النظام على نموذج علائقي معقد يفصل بين الهوية الشخصية وسجلات القيادة المهنية:

جدول الأشخاص المركزي (Person): يرتبط بكل من جداول "المستخدمين" (Users) و"السائقين" (Drivers) لمنع تكرار البيانات الأساسية.

المنطق القائم على الطلبات (Applications): يتم تتبع كل خدمة (إصدار جديد، تجديد، فك حجز) عبر جدول الطلبات لضمان الدقة المالية والإدارية.






