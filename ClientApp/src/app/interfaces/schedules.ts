export interface Lesson {
    object: string;
    date: string;
    comment: string;
    lesson_number: string;
    lesson_name: string;
    lesson_time: string;
    half: string;
    teacher: string;
    teachers_add: string;
    room: string;
    group: string;
    title: string;
    type: string;
    replacement: string;
    reservation: string;
    online: string;
    comment4link: string;
    link: string;
  }

export interface Schedule{
  psrozklad_export: {
    roz_items: Lesson[];
  };
}
