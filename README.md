<!DOCTYPE html>
<html lang="ar" dir="rtl">
<head>
    <meta charset="UTF-8">
    <title>Leap Hero - Project Documentation</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 20px;
            color: #e2e8f0;
            background-color: #0f172a;
            line-height: 1.6;
        }
        .container {
            max-width: 900px;
            margin: auto;
        }
        .header {
            background: linear-gradient(135deg, #1e293b 0%, #0f172a 100%);
            border: 1px solid #334155;
            border-radius: 12px;
            padding: 30px;
            text-align: center;
            margin-bottom: 25px;
            box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.3);
        }
        .header h1 {
            color: #38bdf8;
            margin: 0 0 10px 0;
            font-size: 26pt;
        }
        .header p {
            color: #94a3b8;
            margin: 0;
            font-size: 12pt;
        }
        .badge {
            display: inline-block;
            background-color: #334155;
            color: #38bdf8;
            padding: 4px 12px;
            border-radius: 20px;
            font-size: 9pt;
            font-weight: bold;
            margin: 5px 4px;
        }
        .section {
            background-color: #1e293b;
            border: 1px solid #334155;
            border-radius: 10px;
            padding: 20px;
            margin-bottom: 20px;
        }
        h2 {
            color: #38bdf8;
            font-size: 14pt;
            border-bottom: 2px solid #334155;
            padding-bottom: 8px;
            margin-top: 0;
        }
        h3 {
            color: #f1f5f9;
            font-size: 12pt;
        }
        ul {
            padding-right: 20px;
        }
        li {
            margin-bottom: 6px;
        }
        .code-block {
            background-color: #090d16;
            border: 1px solid #334155;
            border-radius: 6px;
            padding: 12px;
            font-family: 'Courier New', Courier, monospace;
            font-size: 10pt;
            color: #34d399;
            direction: ltr;
            text-align: left;
            margin: 10px 0;
            white-space: pre-wrap;
            overflow-x: auto;
        }
        .team-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }
        .team-table th, .team-table td {
            border: 1px solid #334155;
            padding: 10px;
            text-align: right;
        }
        .team-table th {
            background-color: #0f172a;
            color: #38bdf8;
        }
        .footer {
            text-align: center;
            font-size: 9pt;
            color: #64748b;
            margin-top: 30px;
            border-top: 1px solid #1e293b;
            padding-top: 15px;
        }
    </style>
</head>
<body>

<div class="container">
    <div class="header">
        <h1>🎮 Leap Hero - 2D Platformer</h1>
        <p>مشروع لعبة تفاعلية مطورة باستخدام Unity لنظام الجسيمات وأنظمة الطاقة</p>
        <div>
            <span class="badge">CPCS 494</span>
            <span class="badge">Unity 6</span>
            <span class="badge">C#</span>
            <span class="badge">جامعة الملك عبدالعزيز</span>
        </div>
    </div>

    <div class="section">
        <h2>📌 نظرة عامة على المشروع (Project Overview)</h2>
        <p>لعبة منصات ثنائية الأبعاد تم تطويرها كجزء من متطلبات مقرر CPCS 494 تحت إشراف الدكتور <strong>عماد البسام</strong>[cite: 1]. يركز المشروع على دمج عناصر تحكم فيزيائية ومؤثرات بصرية متقدمة لتحسين تجربة اللاعب[cite: 1].</p>
    </div>

    <div class="section">
        <h2>✨ المتطلبات الخاصة والخصائص المنفذة (Special Requirements)</h2>
        <h3>1. تأثير الغبار عند الهبوط (Landing Dust Effect)</h3>
        <p>تفعيل نظام جسيمات (Particle System) مخصص يظهر بشكل خفيف وسريع عند اصطدام اللاعب بالأرض[cite: 1]:</p>
        <ul>
            <li><strong>المدة (Duration):</strong> 0.3 ثانية[cite: 1]</li>
            <li><strong>العمر الافتراضي (Start Lifetime):</strong> 0.2 ثانية[cite: 1]</li>
            <li><strong>السرعة والحجم:</strong> سرعة 0.5 وحجم 0.4 بنظام محاكاة عالمي (World Simulation Space)[cite: 1]</li>
        </ul>

        <h3>2. نظام الطاقة والجوهرة (Power-Up System)</h3>
        <p>نظام تفاعلي يعتمد على جمع جوهرة في المستوى لتفعيل قدرات مؤقتة للاعب لمدة 30 ثانية[cite: 1]:</p>
        <ul>
            <li>تغيير لون الكيان وتطبيق تأثير التدرج اللوني النبضي (Pulsing Color Effect) باستخدام الكوروتين (Coroutines)[cite: 1].</li>
            <li>مضاعفة قوة القفز (Jump Force) مؤقتة[cite: 1].</li>
            <li>استعادة الخصائص الأصلية تلقائياً بعد انتهاء المدة[cite: 1].</li>
        </ul>
        
        <div class="code-block">private System.Collections.IEnumerator PulseColorAndBoost(Color targetColor, float pulseDuration, float totalDuration)
{
    isPulsing = true;
    Color originalColor = spriteRenderer.color;
    float elapsed = 0f;
    playerMovement.jumpForce = boostedJumpForce;

    while (elapsed < totalDuration)
    {
        float timer = 0f;
        while (timer < pulseDuration)
        {
            timer += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(originalColor, targetColor, timer / pulseDuration);
            yield return null;
        }

        timer = 0f;
        while (timer < pulseDuration)
        {
            timer += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(targetColor, originalColor, timer / pulseDuration);
            yield return null;
        }
        elapsed += pulseDuration * 2;
    }
}</div>
    </div>

    <div class="section">
        <h2>📂 هيكل الملفات في مستودع GitHub</h2>
        <div class="code-block">├── Scripts/                  # الأكواد البرمجية (حركة اللاعب، الطاقة، المؤثرات)
├── Leap Hero (Gameplay).mp4  # فيديو توضيحي لطريقة اللعب والتأثيرات
├── Leap Hero Report.pdf      # التقرير الفني الشامل للمشروع
└── README.md                 # ملف الوثائق والتعريف بالمشروع</div>
    </div>

    <div class="section">
        <h2>👥 فريق العمل (Project Team)</h2>
        <table class="team-table">
            <tr>
                <th>اسم الطالب</th>
                <th>الرقم الجامعي</th>
                <th>المسؤوليات والأدوار</th>
            </tr>
            <tr>
                <td>خالد سالم طيب (Khaled Salem Tayeb)</td>
                <td>2244524</td>
                <td>تطوير نظام الطاقة والجوهرة (Special Requirement 2)، وكتابة التقرير[cite: 1]</td>
            </tr>
            <tr>
                <td>علوي طه العبار (Alawi Taha Albar)</td>
                <td>2236618</td>
                <td>تطوير نظام تأثيرات الغبار عند الهبوط (Special Requirement 1)[cite: 1]</td>
            </tr>
        </table>
    </div>

    <div class="footer">
        جامعة الملك عبدالعزيز - كلية الحاسبات وتقنية المعلومات | مقرر CPCS 494
    </div>
</div>

</body>
</html>
