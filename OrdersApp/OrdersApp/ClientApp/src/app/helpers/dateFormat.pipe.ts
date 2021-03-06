import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment';
@Pipe({
  name: 'format'
})

export class DateFormatPipe implements PipeTransform {
  transform(value: any, format: string = ''): string {
    const momentDate = moment(value);

    if (!momentDate.isValid()) {
      return value;
    }

    return momentDate.format(format);
  }
}
