   M S B A M L   `   `   `  ����  Management-Hotel3    -Management_Hotel.Views.RoomTypeManagementView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .��5      � $��20q�6     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Types de Chambres��6   $��24(�6-   $��0,0,0,20q�6;   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,20q�6;   .+�5      �� -   5        $��Nouveau Type��5      $	��150��5      $��30��6!   $��0,0,10,0q�6-   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ RoomTypesGrid��5       $��2��6      AutoGenerateColumns$ False��5         
IsReadOnly$
 True��6/      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Libellé��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	Libelle+  5      $ Description��6%    6:   �� *Description+  5      $ 	Capacité��6%    67   �� *
Capacite+  5      $ 	Prix/Nuit��6%    68   �� *
Prixnuit+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Actions��6)      CellTemplate 5      �� 5      .R�5      �� $ 
Horizontal=�6)   .+�5   "   �� -   5        $��Modifier��5   )   $��0,0,5,0q�5   )   �� 5   "   -   5        $��	Supprimer��5   )   6=   5       5!      5#      5%      5&      5'      