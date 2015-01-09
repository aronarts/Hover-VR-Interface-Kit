﻿namespace Henu.Navigation {

	/*================================================================================================*/
	public interface INavDelegate {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		NavItemData[] GetTopLevelItems();

		/*--------------------------------------------------------------------------------------------*/
		void HandleItemSelection(NavItemData pItemData);

		/*--------------------------------------------------------------------------------------------*/
		void HandleLevelChange(NavItemData[] pItemDataList, int pDirection);

	}

}