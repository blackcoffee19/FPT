#include <stdio.h>
#include <conio.h>

typedef struct
{
    int h;
    int m;
    int s;
} TIME, *PTIME;
 
void inputTime(PTIME time);
void dispTime(TIME time);
TIME calcTime(TIME time1, TIME time2);
 
int main() {
    TIME time1,time2,time;
    //time1
    inputTime(&time1);
    printf("\n(Time 1) ");
    dispTime(time1);
    //time2
    inputTime(&time2);
    printf("\n(Time 2) ");
    dispTime(time2);
    // time = |tim1 - time2|;
    printf("\n(Time 2 - Time 1) ");
    time = calcTime(time1, time2);
    dispTime(time);
    getch();
}
 
/*****************************************************************
Description: - display time like hh:mm:ss
return : void
******************************************************************/
void dispTime(TIME time) {
    printf("hh:mm:ss = %.2d:%.2d:%.2d\n", time.h, time.m, time.s);
}
 
/*****************************************************************
Description: - import time
- save h,m,s to struct time
- return : void
******************************************************************/
void inputTime(PTIME time) {
    int h,m,s;
    printf("\nInput time:");
    // Hour
    do {
        printf("\nHour: ");
        scanf("%d", &h);
    } while (h < 0 || h > 23);
    // Minute
    do {
        printf("\nMinute: ");
        scanf("%d", &m);
    } while (m < 0 || m > 59);
    // Sencond
    do {
        printf("\nSecond: ");
        scanf("%d", &s);
    } while (s < 0 || s > 59);
 
    //save this time to struct
    time->h = h;
    time->m = m;
    time->s = s; 
}
 
TIME calcTime(TIME time1, TIME time2) {
    int s1 = 0, s2 = 0;
    int s;
    TIME time;
    s1 = 60*60*time1.h + 60*time1.m + time1.s;
    s2 = 60*60*time2.h + 60*time2.m + time2.s;
    s = s1 - s2;
    if(s < 0) {
        s = (-1)*s;
    }
    time.m = s/60;
    time.s = s%60;
    time.h = time.m/60;
    time.m = time.m%60;
 
    return time;
}

