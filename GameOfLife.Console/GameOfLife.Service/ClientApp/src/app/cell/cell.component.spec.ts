import { HttpClientModule } from '@angular/common/http';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { BackEndService } from '../services/backend.service';

import { CellComponent } from './cell.component';

describe('CellComponent', () => {
  let service: BackEndService;
  let component: CellComponent;
  let fixture: ComponentFixture<CellComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CellComponent],
      imports: [HttpClientModule],
      providers: [{ provide: 'BASE_URL', useValue: 'http://baseurl.com/' }]
    })
      .compileComponents();
    fixture = TestBed.createComponent(CellComponent);
    component = fixture.componentInstance;
    service = fixture.debugElement.injector.get(BackEndService);

    fixture.detectChanges();
  }));

  function changeRow(value: string) {
    const fieldInput: HTMLInputElement = fixture.debugElement.query(By.css('#row')).nativeElement;
    fieldInput.value = value;
    fieldInput.dispatchEvent(new Event('input'));
    fixture.detectChanges();

    return fieldInput;
  }

  function changeColumn(value: string) {
    const fieldInput: HTMLInputElement = fixture.debugElement.query(By.css('#column')).nativeElement;
    fieldInput.value = value;
    fieldInput.dispatchEvent(new Event('input'));
    fixture.detectChanges();

    return fieldInput;
  }

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should allow the user to specify the row', () => {
    const value = '3';

    const fieldInput = changeRow(value);

    //taking the value from the UI
    expect(fieldInput.value).toContain('3');
  });


  it('should store row value when user clicks Submit', () => {
    const value = '5';
    const fieldInput = changeRow(value);

    const buttonSubmit: HTMLButtonElement = fixture.debugElement.query(By.css('#create-grid')).nativeElement;
    buttonSubmit.click();
    fixture.detectChanges();

    //recording the value into the component
    expect(component.row).toContain(5);
  });

  it('should allow the user to specify the column', () => {
    const value = '4';

    const fieldInput = changeColumn(value);

    //taking the value from the UI
    expect(fieldInput.value).toContain('4');
  });

  it('should store column value when user clicks Submit', () => {
    const value = '3';
    const fieldInput = changeColumn(value);

    const buttonSubmit: HTMLButtonElement = fixture.debugElement.query(By.css('#create-grid')).nativeElement;
    buttonSubmit.click();
    fixture.detectChanges();

    //recording the value into the component
    expect(component.column).toContain(3);
  });

  it('should call the method CreateGrid in the backend', () => {
    const value = ' ';
    const fieldInput = changeRow(value);
    const secondFieldInput = changeColumn(value);

    const spy = spyOn(service, 'requestGrid');

    const buttonSubmit: HTMLButtonElement = fixture.debugElement.query(By.css('#create-grid')).nativeElement;
    buttonSubmit.click();
    fixture.detectChanges();

    expect(spy).toHaveBeenCalledTimes(1);
  });
});
