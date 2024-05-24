import {ref} from "vue";
/* 
 *  Common Globals
 *  ---------------
 *  Authored: 03/05/24
 * 
 * 
 *  Notes:
 *  ------
 */

export const CurrentUserData = ref({fullUserName: '', roleName: '', profilePicUrl: ''});
export const CurrentUserSettings = ref({dateFormat: '', timeFormat: ''});