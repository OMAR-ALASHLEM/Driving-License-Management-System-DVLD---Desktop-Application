# 🛠️ Database Architecture & Design Logic (DVLD)

## 1. Project Overview
The **DVLD (Driving & Vehicle License Department)** system is a robust solution designed to manage the full lifecycle of driving licenses.
The database is built with a focus on **Normalization**, ensuring zero data redundancy while maintaining high performance for auditing and tracking.


## 2. Structural Layers

### 🔐 Identity & Access Layer
* **Person Table (`Person`):** The core entity where all personal details are stored once.
* **It prevents identity duplication using the **NationalNo** unique constraint.
* **Users Table (`Users`):** Linked to the Person table to provide system access with specific **Permissions**.
* **Drivers Table (`Drivers`):** A person only becomes a "Driver" once they successfully issue their first license.

### 📝 Application Pattern
The system uses an **Inheritance (Super-type / Sub-type)** pattern to manage diverse services:
* **Base Applications (`Applications`):** Stores common metadata for every service (New, Renew, Release), including fees and status.
* **Local License Applications (`LocalDrivingLicenseApplications`):** Extends the base application to specifically handle local license requests and class types.

### 🧪 Testing Engine
* **Test Appointments:** Manages schedules for Vision, Theory, and Practical tests.
* **Retake Mechanism:** Linked via `RetakeTestApplication_ID` to handle failure scenarios where a new application fee is required.

---

## 3. The Data Life Cycle (Business Workflow)

### Stage 1: Submission & Validation
1. **Verification:** System checks if the person exists or needs to be added.
2. **Application Creation:** A record is created in `Applications` with a status of 'New'.
3. **Class Specification:** The specific license class (e.g., Ordinary, Heavy) is linked in `LocalDrivingLicenseApplications`.

### Stage 2: Testing Process
*Applicants must pass three sequential tests:*
1. **Vision Test:** Initial physical eligibility check.
2. **Theory Test:** Traffic laws and safety knowledge.
3. **Practical Test:** Hands-on driving evaluation.
**Note:** Failed tests require a "Retake Application" with additional fees.

### Stage 3: Issuance
*Upon passing all tests, a record is added to the `Drivers` table (if not already a driver).
* A new `License` record is generated with a validity period based on the class (e.g., 10 years for Ordinary Class).

---

## 4. Integrity & Auditing
* **User Tracking:** Every transaction records the `CreatedByUserID` to ensure administrative accountability.
* **Status Control:** `ApplicationStatus` monitors the lifecycle from 'New' to 'Completed' or 'Cancelled'.
* **Data Security:** Strict relational integrity (Foreign Keys) prevents orphaned records in license or test tables.

---

# 🛠️ بنية قاعدة البيانات ومنطق التصميم (DVLD) -

## 1. نظرة عامة على المشروع
نظام **DVLD (إدارة ترخيص السواقين والمركبات)** هو حل برمجى متكامل لإدارة دورة حياة رخص القيادة بالكامل. تم بناء قاعدة البيانات مع التركيز على **المعيارية (Normalization)** لضمان عدم تكرار البيانات والحفاظ على أداء عالٍ في عمليات التدقيق والتتبع.

---

## 2. الطبقات الهيكلية

### 🔐 طبقة الهوية والوصول (Identity & Access Layer)
* **جدول الأشخاص (`Person`):** هو الكيان المركزي حيث تُخزن فيه كافة البيانات الشخصية لمرة واحدة فقط لمنع التكرار.
* **جدول المستخدمين (`Users`):** يرتبط بجدول الأشخاص لمنح حق الوصول للنظام مع **صلاحيات** محددة.
* **جدول السائقين (`Drivers`):** لا يصبح الشخص "سائقاً" في النظام إلا بعد حصوله على أول رخصة قيادة بنجاح.

### 📝 نمط إدارة الطلبات (Application Pattern)
يعتمد النظام نمط **Inheritance (Super-type / Sub-type)** لإدارة الخدمات المتنوعة:
* **الطلبات الأساسية (`Applications`):** تخزن البيانات المشتركة لكل نوع خدمة (جديد، تجديد، فك حجز) بما في ذلك الرسوم والحالة.
* **طلبات الرخص المحلية (`LocalDrivingLicenseApplications`):** امتداد للطلب الأساسي للتعامل خصيصاً مع فئات الرخص المحلية.

### 🧪 محرك الاختبارات (Testing Engine)
* **مواعيد الاختبارات:** يدير جداول فحص النظر، الاختبار النظري، والاختبار العملي.
* **آلية إعادة الاختبار:** يرتبط عبر `RetakeTestApplication_ID` للتعامل مع حالات الرسوب التي تتطلب طلب إعادة فحص برسوم جديدة.


## 3. دورة حياة البيانات (سير العمل)

### المرحلة 1: إنشاء الطلب والتحقق
1. **التحقق:** يتأكد النظام ما إذا كان الشخص موجوداً مسبقاً أو يحتاج لإضافة.
2. **إنشاء الطلب:** يتم تسجيل سجل في `Applications` بحالة 'New'.
3. **تحديد الفئة:** يتم تحديد فئة الرخصة المطلوبة (مثل: خصوصي، شحن) في جدول الطلبات المحلية.

### المرحلة 2: مرحلة التقييم (الاختبارات)
*يجب على المتقدم اجتياز الاختبارات الثلاثة بالترتيب التالي:*
1. **فحص النظر:** التحقق الأولي من الأهلية الجسدية.
2. **الاختبار النظري:** تقييم المعرفة بقوانين المرور والسلامة.
3. **الاختبار العملي:** تقييم مهارات القيادة الميدانية.
> **ملاحظة:** في حال الرسوب، يتطلب الأمر "طلب إعادة فحص" ورسوم إضافية.

### المرحلة 3: مرحلة الإصدار
* بمجرد النجاح في كافة الاختبارات، يتم إنشاء سجل في جدول `Drivers` (إن لم يكن موجوداً).
* يتم إصدار رخصة جديدة في جدول `Licenses` بمدة صلاحية تعتمد على فئتها (مثلاً 10 سنوات للفئة الثالثة).


## 4. الرقابة والتدقيق (Integrity & Auditing)
* **تتبع المستخدمين:** كل حركة تسجل معرف المستخدم `CreatedByUserID` لضمان المساءلة الإدارية.
* **مراقبة الحالة:** يتابع حقل `ApplicationStatus` دورة حياة الطلب من البداية وحتى الإغلاق أو الإلغاء.
* **سلامة البيانات:** تمنع القيود العلائقية (Foreign Keys) وجود سجلات يتيمة في جداول الرخص أو الاختبارات.
