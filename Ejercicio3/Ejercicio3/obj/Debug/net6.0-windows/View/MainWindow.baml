   M S B A M L   `   `   `  ����E  AEjercicio3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ejercicio3
Ejercicio3  5   	       Ejercicio3.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Ejercicio3     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��97* �6   �� 5      $	��63* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   .+�5      �� $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ btnNew��5      $	��NEW��6)   $��20q�67   6Z   �� 5      -   5        $ btnDel��5      $	��DEL��6)   $��20q�67   6Z   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ 	dgvPeople��5         AutoGenerateColumns$ False��6*      
IsReadOnly$
 True��6F   $��5q�6X      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 NIF��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� *nif+6P     5      $
 NAME��6)   	 67   �� *name+6R     5      $ SURNAME��6)   	 6:   �� *	surname+6X     5      $	 AGE��6)   	 66   �� *age+6P   5      5      �� 5   
   $ Vertical=�6   $��1��6,   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Nif: ��6   $��5q�6(   65   �� 5       -   5        
 ��Name$
 txtNif��5       $��5q�6*   $	��100��65   6C   5!      �� 5"      $ 
Horizontal=�6   .+�5#      �� $��Name: ��6   $��5q�6)   67   �� 5$      -   5        $
 txtName��5$      $��5q�6+   $	��200��66   6D   5%      �� 5&      $ 
Horizontal=�6   .+�5'      �� $��	Surname: ��6   $��5q�6,   69   �� 5(      -   5        $
 
txtSurname��5(      $��5q�6.   $	��200��69   6G   5)      �� 5*      $ 
Horizontal=�6   .+�5+      �� $��Age: ��6   $��5q�6(   65   �� 5,      -   5        $
 txtAge��5,      $��5q�6*   $	��100��65   6C   5-      �� 5.      -   5        $ btnSave��5.      $
��Save��6&   $��1��65   $��20q�6E   6Q   5/      50      51      