import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phoneNumber'
})
export class PhoneNumberPipe implements PipeTransform {

  transform(value: string, ...args: unknown[]): unknown {
    return value.slice(0,3)+" "+value.slice(3,6)+"-"+value.slice(6,value.length)
  }

}
