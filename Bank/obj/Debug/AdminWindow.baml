   M S B A M L   `   `   `  ����?  ;Bank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BankBank  5   	       Bank.AdminWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Bank     5   	     � Title$  Administrator Panel��5   	   $	��350��6%   $	��500��62   .��5	      � $��20q�6    � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��35 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgUsers��5      $��3��5      $��5q�5         
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $
 Name��6%    63   �� *Name+  5      $ Account Number��6%    6=   �� 	 �� Path$	 UserAccount.AccountNumber�  5      $ Balance��6%    66   �� $	 UserAccount.Balance�5      �� 5!   
   -   5        
 ��Name$
 btnAdd��5!      $	��Add��5"      $��1��5#      $��5q�5$      5%      �� 5&   
   -   5        $
 	btnUpdate��5&      $��Update��5'      $��1��5(      $��1��5)      $��5q�5*      5+      �� 5,   
   -   5        $
 	btnDelete��5,      $��Delete��5-      $��2��5.      $��1��5/      $��5q�50      51      52      53      