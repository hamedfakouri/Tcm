import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'داشبورد',
    icon: 'nb-home',
    link: '/',
    home: true,
  },
  {
    title: 'شناسنامه مدارس',
    icon: 'nb-home',
    link: 'School',
    home: true,
  },
  {
    title: 'FEATURES',
    group: true,
  },
  {
    title: 'اطلاعات پایه',
    icon: 'nb-star',
    children: [
      {
        title: 'مقطع تحصیلی',
        link: 'educationLevel',
      },
      {
        title: 'دوره تحصیلی',
        link: 'EducationCourse',
      },
      {
        title: 'پایه تحصیلی',
        link: 'EducationSubCourse',
      },
      {
        title: 'رشته تحصیلی',
        link: 'Major',
      },
      {
        title: 'نوع مدرسه',
        link: 'SchoolType',
      },
      {
        title: 'دسته بندی مدارس',
        link: 'SchoolSubType',
      },
    ],
  },
  {
    title: 'کاربر',
    icon: 'nb-keypad',
    children: [
      {
        title: 'مدیر مدرسه',
        link: '/account/register/Manager',
      },
      {
        title: 'ایجاد دانش آموز',
        link: '/account/register',
      },
      {
        title: 'ایجاد پرسنل',
        link: '/account/register/Personel'
      }
    ],
  }
];
