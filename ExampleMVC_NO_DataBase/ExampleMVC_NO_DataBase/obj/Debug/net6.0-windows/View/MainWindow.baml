   M S B A M L   `   `   `  ����Q  MExampleMVC_NO_DataBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ExampleMVC_NO_DataBaseExampleMVC_NO_DataBase  5   	   '    !ExampleMVC_NO_DataBase.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ExampleMVC_NO_DataBase     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��50* �6   �� 5      $��3* �6   �� 5      $	��47* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgPeople��5         AutoGenerateColumns$ False��6%      
IsReadOnly$
 True��6A   $��5,5,5,5q�6S      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 NAME��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6N     5      $	 AGE��6%    62   �� *Age+6L   5      �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   $��2��6<   .+�5      �� -   5        	 ��Name$	 
btnExample��5      $��Push me��6)   $��1��6;   $��20q�6K   6r   �� 5      -   5        
 ��Name$
 
boxExample��5      5      5      5      