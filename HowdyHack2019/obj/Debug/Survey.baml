   M S B A M L   `   `   `  ����H  DHowdyHack2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HowdyHack2019HowdyHack2019  5   	       HowdyHack2019.Survey   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:HowdyHack2019     5   	     � Title$  Survey��5   	   $	��500��6   $	��800��6%   ���#FCD2CF���#800000.��5	      � .+�5
   
   �� $��Grade: ��6   $��	90,10,0,0q�6"   67   �� 5   
   .+�5      �� -   5         ��Name$ gradeComboBox��5      $	��200��6.   $��
0,15,300,0q�6:   .@�5      �� .��6   
Freshman6)   �� 5      .��6   
Sophmore6)   �� 5      .��6   Junior6'   �� 5      .��6   Senior6'   �� 5      .��6   
Graduate6)   5      5      �� 5   
   $��Choose your language:��6   $��
10,100,0,0q�60   6F   �� 5   
   .+�5      �� -   5        $ languageComboBox��5      $	��200��61   $��0,105,300,0q�6=   .@�5      �� .��6   C6"   �� 5      .��6   C++6$   �� 5      .��6   C#6#   �� 5      .��6   Java6%   �� 5      .��6   
JavaScript6+   �� 5      .��6   Python6'   �� 5      .��6   Ruby6%   �� 5      .��6   Swift6&   �� 5       .��6   Go6#   5!      5"      �� 5$   
   $$��Coding experience (in years)?:��6   $��	0,200,0,0q�69   6N   �� 5%   
   $����0            1            2            3            4            5            6            7            8            9           10��6   $��173,225,0,0q�6�   6�   �� 5&   
   $��Center=�6   $��175,0,150,35q�60   .+�5'      �� -   5         ��Name$ years��5'   k    � Maximum$ 10Q�6    �� TickPlacement$ BottomRight=�6"    �� TickFrequency$ 1Q�6>    �� IsSnapToTickEnabled . 6{   5)      �� 5*   
   $0��*Are you willing to teach someone to code?:��6   $��0,290,400,0q�6E   6\   �� 5+   
   .+�5,      �� -   5        $ teachComboBox��5,      $	��100��6.   $��0,293,200,0q�6:   .@�5-      �� .��6   Yes6$   �� 5.      .��6   No6#   5/      50      �� 52   
   $2��,Are you willing to learn another language?: ��6   $��0,360,390,0q�6G   6^   �� 53   
   .+�54      �� -   5        $ learnComboBox��54      $	��100��6.   $��0,360,200,0q�6:   .@�55      �� .��6   Yes6$   �� 56      .��6   No6#   57      �� 58      -   5         ��Name$ 	btnSubmit��58      $��Submit��6(   $��5q�69   6D   59      5:      5;      