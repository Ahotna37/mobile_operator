   M S B A M L   `   `   `  ����E  ADragablz, Version=0.0.3.223, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz  5      F BMobOperator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MobOperator.ViewMobOperator.View 5      #   MobOperator.View.Registration   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =dragablz(clr-namespace:Dragablz;assembly=Dragablz     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      *localclr-namespace:MobOperator.View  5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $��0.12* �6   �� 5      $��* �6   �� 5      $��0.12* �6    � RowDefinitions 5   
   �� 5      $��0.15* �6   �� 5      $��* �6   �� 5      $��0.15* �6   �� 5      $��0.15* �6   �� 5      $��0.15* �6   �� 5      $��0.10* �6   .+�5   
   �� 
�������
�������$��0��6=   $��3��6M   $��1q�6a   $��16��6u   5      �� 5   
   $��0��6   $��10��6"   $��0��67   $	��100��6D   $��20q�6X   $	��Top=�6e   $��Center=�6}   $��25(�6�   $��Регистрация��6�   $
��Bold"�6�   � 5   
   $��1��6   $��1��6   .+�5      �� $��1��6   $��1��6*   $��9��67   .@�5       �� $#��Физическое лицо��6   .��5!      �   5"      �� 5#      $��0.03* �6/   �� 5$      $��0.50* �6/   �� 5%      $��* �6/   �� 5&      $
��0.1* �6/   �� 5'      $
��0.1* �6/    5)      �� 5*      $��* �6,   �� 5+      $��* �6,   �� 5,      $��* �6,   �� 5-      $��* �6,   �� 5.      $��* �6,   �� 5/      $��* �6,   .+�53      �� $��1��6    $��0��60   $��Bottom=�6>   $
��Left=�6Y   $
��Bold"�6t   $��Имя��6�   �� 54      $��2��6�   $��0��6�   
���� ��$��0 0 0 1q�6�   $��Bottom=�6�   ��6"   �� *TextBoxNameText+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 55      $��1��6    $��1��60   $��Bottom=�6>   $
��Left=�6Y   $
��Bold"�6t   $��Фамилия��6�   �� 56      $��2��6�   $��1��6�   
���� ��$��0 0 0 1q�6�   $��Bottom=�6�   ��6"   �� *TextBoxSurNameText+$ OneWayToSource=�$ PropertyChanged=�6�   �� 57      $��1��6    $��2��60   $��Bottom=�6>   $
��Left=�6Y   $
��Bold"�6t   $��Дата рождения��6�   �� 58      $��2��6�   $��2��6�   
���� ��$��0 0 0 1q�6�   $��Bottom=�6�   ��6"   �� *TextBoxDateOfBirthText+$ OneWayToSource=�$ PropertyChanged=�6�   �� 59      $��1��6    $��3��60   $��Bottom=�6=   $
��Left=�6X   $
��Bold"�6s   $"��Номер паспорта ��6�   �� 5;      $��2��6�   $��3��6�   
���� ��$��0 0 0 1q�6�   $��Bottom=�6�   ��6"   �� *TextBoxNumberPassportText+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5<      $��1��6    $��4��60   $��Bottom=�6=   $
��Left=�6X   $
��Bold"�6s   $��Пароль��6�   �� 5>      $��2��6�   $��4��6�   
���� ��$��0 0 0 1q�6�   $��Bottom=�6�   ��6"   �� *TextBoxPasswordPhysicalText+$ OneWayToSource=�$ PropertyChanged=�6�   5?      5@      �� 5A      $%��Юридическое лицо��6   .��5B      �   5C      �� 5D      $	��17* �6/   �� 5E      $	��67* �6/   �� 5F      $
��211* �6/   �� 5G      $
��556* �6/   �� 5H      $	��56* �6/   �� 5I      $	��55* �6/    5K      �� 5L      $��* �6,   �� 5M      $��* �6,   �� 5N      $��* �6,   �� 5O      $��* �6,   �� 5P      $��* �6,   �� 5Q      $��* �6,   .+�5S      �� $��1��6    $��0��60   $��Bottom=�6=   $
��Left=�6X   $
��Bold"�6s   $-��'Название организации��6�   $��2��6�   5T      �� 5U      $��3��6�   $��0��6�   
���� ��$��0 0 0 1q�6�   $��Bottom=�6�   $��1��6�   ��6"   �� *TextBoxNameOrganizationText+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5V      $��1��6    $��1��60   $��Bottom=�6=   $
��Left=�6X   $
��Bold"�6s   $'��!Юридический адрес��6�   $��2��6�   �� 5X      $��3��6�   $��1��6�   
���� ��$��0 0 0 1q�6�   $��Bottom=�6�   $��1��6�   ��6"   �� *TextBoxLegalAdressText+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5Y      $��1��6    $��2��60   $��Bottom=�6=   $
��Left=�6X   $
��Bold"�6s   $��ИНН��6�   �� 5Z      $��3��6   $��2��6�   
���� ��$��0 0 0 1q�6�   $��Bottom=�6�   $��1��6�   ��6"   �� *TextBoxITNText+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5[      $��1��6    $��3��60   $��Bottom=�6=   $
��Left=�6X   $
��Bold"�6s   $��Начало работы��6�   $��2��6�   �� 5\      $��3��6�   $��3��6�   
���� ��$��0 0 0 1q�6�   $��Bottom=�6�   $��1��6�   ��6"   �� *TextBoxStartWorkText+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5]      $��1��6    $��4��60   $��Bottom=�6=   $
��Left=�6X   $
��Bold"�6s   $��Пароль��6�   $��2��6�   �� 5^      $��3��6�   $��4��6�   
���� ��$��0 0 0 1q�6�   $��Bottom=�6�   $��1��6�   ��6"   �� *TextBoxPasswordLegalText+$ OneWayToSource=�$ PropertyChanged=�6�   5_      5`      5a      5b      �� 5c   
   $��1��6   $��2��6"   $��Bottom=�61   $��20(�6N   $��Center=�6^   
��� E��$
��Bold"�6�   ��6�   �� *LabelErrorReg+$ TwoWay=�$ PropertyChanged=�6�   �� 5d   
   $��Создать��6D   $��16(�6X   $��1��6f   $��3��6v   $	��300��6�   ��6   �� *LoadMainWindow+$ OneTime=�6�   �� 5e   
   $��
Назад��6F   $��1��6X   $��16(�6h   $��4��6v   $	��300��6�   ��6   �� *LoadAutorisation+$ OneTime=�6�   5f      5g      