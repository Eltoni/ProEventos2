import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe} from '@angular/common';
import { Constants } from '../util/constants';

@Pipe({
  name: 'DataTimeFormatPipe'
})
export class DataTimeFormatPipePipe extends DatePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return super.transform(value, Constants.DATE_TIME);
  }

}
