﻿import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'sorter'
})

export class OrderByPipe implements PipeTransform {
    transform(records: Array<any>, args?: any): any {
        return records.sort(function (a, b) {
            if (a[args.property] < b[args.property]) {
                return -1 * args.retning;
            }
            else if (a[args.property] > b[args.property]) {
                return 1 * args.retning;
            }
            else {
                return 0;
            }
        });
    };
}
